using Grpc.Core;
using Grpc.Core.Interceptors;

namespace NSE.Bff.Compras.Services.gRPC
{
    // Funciona similar ao HttpInterceptor do angular e DelegatingHandler do HttpClient do C#
    public class GrpcServiceInterceptor : Interceptor
    {
        private readonly ILogger<GrpcServiceInterceptor> _logger;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public GrpcServiceInterceptor(
            ILogger<GrpcServiceInterceptor> logger,
            IHttpContextAccessor httpContextAccesor)
        {
            _logger = logger;
            _httpContextAccesor = httpContextAccesor;
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request, 
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            // Obtém o token do http context. Não usa o IAspNetUser porque Interceptor é singleton
            var token = _httpContextAccesor.HttpContext?.Request.Headers["Authorization"];

            var headers = new Metadata
            {
                {"Authorization", token }
            };

            // Adicionar as headers com o token obtido da request do HttpContext
            var options = context.Options.WithHeaders(headers);

            // Utiliza o mesmo ClientInterceptor, mas colocando as options criada acima com o token obtido do HttpContext
            context = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, options);

            // Segue em frente com o novo context com os headers de autenticação
            return base.AsyncUnaryCall(request, context, continuation);
        }
    }
}