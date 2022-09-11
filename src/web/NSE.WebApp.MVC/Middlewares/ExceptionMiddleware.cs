using System.Net;
using System.Threading.Tasks;
using Grpc.Core;
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
                HandleRequestExceptionAsync(httpContext, ex.StatusCode);
            }
            catch (BrokenCircuitException)
            {
                HandleCircuitBreakerExceptionAsync(httpContext);
            }
            catch (RpcException ex)
            {
                //400 Bad Request	    INTERNAL
                //401 Unauthorized      UNAUTHENTICATED
                //403 Forbidden         PERMISSION_DENIED
                //404 Not Found         UNIMPLEMENTED

                var statusCode = ex.StatusCode switch
                {
                    StatusCode.Internal => 400,
                    StatusCode.Unauthenticated => 401,
                    StatusCode.PermissionDenied => 403,
                    StatusCode.Unimplemented => 404,
                    _ => 500
                };

                var httpStatusCode = (HttpStatusCode)statusCode;

                HandleRequestExceptionAsync(httpContext, httpStatusCode);
            }
        }

        private static void HandleRequestExceptionAsync(HttpContext context, HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                // Tenta renovar o RefreshToken, caso TokenExpirado seja verdadeiro
                if (_autenticacaoService.TokenExpirado() && 
                    _autenticacaoService.RefreshTokenValido().Result)
                {
                    context.Response.Redirect(context.Request.Path);
                    return;
                }

                // Usuário não é válido e não tem nada a ver com o token expirado.
                _autenticacaoService.Logout();

                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)statusCode;
        }

        private static void HandleCircuitBreakerExceptionAsync(HttpContext context)
            => context.Response.Redirect("/sistema-indisponivel");
    }
}