using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Core.Messages.Integration;
using NSE.Identidade.API.Models;
using NSE.Identidade.API.Services;
using NSE.Infra.MessageBus;
using NSE.WebAPI.Core.Controllers;

namespace NSE.Identidade.API.Controllers
{
    [ApiController]
    [Route("api/identidade")]
    public class AuthController : MainController
    {
        private readonly AuthService _authService;
        private readonly IMessageBus _bus;

        public AuthController(
            IMessageBus bus,
            AuthService authService)
        {
            _bus = bus;
            _authService = authService;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _authService.UserManager.CreateAsync(usuario, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                var clienteResult = await RegistrarCliente(usuarioRegistro);

                if (clienteResult.ValidationResult.IsValid == false)
                {
                    await _authService.UserManager.DeleteAsync(usuario);
                    return CustomResponse(clienteResult.ValidationResult);
                }

                var respotaLoginVM = await _authService.GerarJwt(usuario.Email);
                return CustomResponse(respotaLoginVM);
            }

            return CustomErrorResponse(result.Errors.Select(e => e.Description).ToArray());
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _authService.SignInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var respotaLoginVM = await _authService.GerarJwt(usuarioLogin.Email);
                return CustomResponse(respotaLoginVM);
            }

            if (result.IsLockedOut)
                return CustomErrorResponse("Usuário temporiariamente bloqueado por ter feito várias tentativas de entrada inválidas!");

            return CustomErrorResponse("Usuário ou senha inválidos.");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken)) 
                return CustomErrorResponse("Refresh Token inválido");

            var token = await _authService.ObterRefreshToken(Guid.Parse(refreshToken));

            if (token is null)
                return CustomErrorResponse("Refresh Token expirado");

            // Cria nova resposta com novo JWT e refresh token
            var respostaComNovoToken = await _authService.GerarJwt(token.Username);

            return CustomResponse(respostaComNovoToken);
        }

        private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistro usuarioRegistro)
        {
            var usuario = await _authService.UserManager.FindByEmailAsync(usuarioRegistro.Email);

            var usuarioRegistrado = new UsuarioRegistradoIntegrationEvent(
                Guid.Parse(usuario.Id), usuarioRegistro.Nome, usuarioRegistro.Email, usuarioRegistro.Cpf
            );

            try
            {
                var responseMessage = await _bus.RequestAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(usuarioRegistrado);
                return responseMessage;
            }
            catch (Exception)
            {
                await _authService.UserManager.DeleteAsync(usuario);
                throw;
            }
        }
    }
}
