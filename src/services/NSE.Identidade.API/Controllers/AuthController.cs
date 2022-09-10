using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using NSE.Core.Messages.Integration;
using NSE.Identidade.API.Models;
using NSE.Infra.MessageBus;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Identidade;
using NSE.WebAPI.Core.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NSE.Identidade.API.Controllers
{
    [ApiController]
    [Route("api/identidade")]
    public class AuthController : MainController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMessageBus _bus;
        private readonly IAspNetUser _aspNetUser;
        private readonly IJwtService _jwksService;

        public AuthController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IMessageBus bus,
            IAspNetUser aspNetUser,
            IJwtService jwksService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bus = bus;
            _aspNetUser = aspNetUser;
            _jwksService = jwksService;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(UsuarioRegistroViewModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(usuario, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                var clienteResult = await RegistrarCliente(usuarioRegistro);

                if (clienteResult.ValidationResult.IsValid == false)
                {
                    await _userManager.DeleteAsync(usuario);
                    return CustomResponse(clienteResult.ValidationResult);
                }

                var respotaLoginVM = await GerarJwt(usuario.Email);
                return CustomResponse(respotaLoginVM);
            }

            return CustomErrorResponse(result.Errors.Select(e => e.Description).ToArray());
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var respotaLoginVM = await GerarJwt(usuarioLogin.Email);
                return CustomResponse(respotaLoginVM);
            }

            if (result.IsLockedOut)
                return CustomErrorResponse("Usuário temporiariamente bloqueado por ter feito várias tentativas de entrada inválidas!");

            return CustomErrorResponse("Usuário ou senha inválidos.");
        }

        private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistroViewModel usuarioRegistro)
        {
            var usuario = await _userManager.FindByEmailAsync(usuarioRegistro.Email);

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
                await _userManager.DeleteAsync(usuario);
                throw;
            }
        }

        private async Task<UsuarioRespostaLoginViewModel> GerarJwt(string email)
        {
            // TODO Fazer uma refatoração depois colocando em um service com método independentes
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);
            string encodedToken = await CodificarToken(identityClaims);

            return ObterRespostaToken(user, claims, encodedToken);
        }

        private async Task<ClaimsIdentity> ObterClaimsUsuario(IList<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            AdicionarRolesComoClaims(claims, userRoles);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;


            static long ToUnixEpochDate(DateTime date)
                => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

            static void AdicionarRolesComoClaims(IList<Claim> claims, IList<string> roles)
            {
                foreach (string userRole in roles)
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
            }
        }

        private async Task<string> CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = await _jwksService.GetCurrentSigningCredentials();

            // Será o Host onde este servidor de autenticação/identidade está hospedado (é o próprio endpoint da API)
            var currentIssuer = $"{_aspNetUser.ObterHttpContext().Request.Scheme}://{_aspNetUser.ObterHttpContext().Request.Host}";

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = currentIssuer,
                //Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = key
            });

            string encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

        private UsuarioRespostaLoginViewModel ObterRespostaToken(IdentityUser user, IList<Claim> claims, string encodedToken)
        {
            return new UsuarioRespostaLoginViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(1).TotalMilliseconds,
                UsuarioToken = new UsuarioTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaimViewModel
                    {
                        Type = c.Type,
                        Value = c.Value
                    })
                }
            };
        }
    }
}
