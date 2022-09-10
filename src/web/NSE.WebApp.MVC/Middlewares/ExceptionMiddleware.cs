using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NSE.WebApp.MVC.Exceptions;
using NSE.WebApp.MVC.Services.Interfaces;
using Polly.CircuitBreaker;

namespace NSE.WebApp.MVC.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static IAutenticacaoService _autenticacaoService;

        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        // OBS.: Como injeção do IAutenticacaoService é scoped então é injetado no método e não no construtor porque Middlewares são Singleton
        public async Task InvokeAsync(HttpContext httpContext, IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;

            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpRequestException ex)
            {
                HandleRequestExceptionAsync(httpContext, ex);
            }
            catch (BrokenCircuitException)
            {
                HandleCircuitBreakerExceptionAsync(httpContext);
            }
        }

        private static void HandleRequestExceptionAsync(HttpContext context, CustomHttpRequestException httpRequestException)
        {
            if (httpRequestException.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Tenta renovar o RefreshToken, caso TokenExpirado seja verdadeiro
                if (_autenticacaoService.TokenExpirado() && 
                    _autenticacaoService.RefreshTokenValido().Result)
                {
                    context.Response.Redirect(context.Request.Path);
                }

                // Usuário não é válido e não tem nada a ver com o token expirado.
                _autenticacaoService.Logout();

                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)httpRequestException.StatusCode;
        }

        private static void HandleCircuitBreakerExceptionAsync(HttpContext context)
            => context.Response.Redirect("/sistema-indisponivel");
    }
}