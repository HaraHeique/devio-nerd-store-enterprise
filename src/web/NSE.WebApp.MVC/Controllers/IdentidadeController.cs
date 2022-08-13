using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Usuario;
using NSE.WebApp.MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : MainController
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpGet("nova-conta")]
        public IActionResult Registro() => View();

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistroViewModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            var registroResposta = await _autenticacaoService.Registro(usuarioRegistro);

            if (ResponsePossuiErros(registroResposta.ResponseResult)) 
                return View(usuarioRegistro);

            await RealizarLogin(registroResposta);

            return RedirectToAction("Index", "Catalogo");
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null) 
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel usuarioLogin, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(usuarioLogin);

            var loginResposta = await _autenticacaoService.Login(usuarioLogin);

            if (ResponsePossuiErros(loginResposta.ResponseResult))
                return View(usuarioLogin);

            await RealizarLogin(loginResposta);

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Catalogo");

            return LocalRedirect(returnUrl);
        }

        [HttpGet("sair")]
        public async Task<IActionResult> Logout()
        {
            // Limpa o cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Catalogo");
        }

        private async Task RealizarLogin(UsuarioRespostaLoginViewModel resposta)
        {
            var token = ObterTokenFormatado(resposta.AccessToken);

            var claims = new List<Claim> { new Claim("JWT", resposta.AccessToken) };
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            // Cria o cookie
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
        }

        private static JwtSecurityToken ObterTokenFormatado(string token) => 
            new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
    }
}
