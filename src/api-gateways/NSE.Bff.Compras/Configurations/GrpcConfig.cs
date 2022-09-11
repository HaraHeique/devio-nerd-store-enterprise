using NSE.Bff.Compras.Services.gRPC;
using NSE.Carrinho.API.Services.gRPC;

namespace NSE.Bff.Compras.Configurations
{
    public static class GrpcConfig
    {
        public static WebApplicationBuilder ConfigureGrpcServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICarrinhoGrpcService, CarrinhoGrpcService>();
            
            builder.Services.AddSingleton<GrpcServiceInterceptor>();
            builder.Services.AddGrpcClient<CarrinhoCompras.CarrinhoComprasClient>(options =>
            {
                options.Address = new Uri(builder.Configuration["CarrinhoUrl"]);
                //options.Address = new Uri(builder.Configuration.GetValue<string>("CarrinhoUrl"));
            })
            .AddInterceptor<GrpcServiceInterceptor>();
            //.AllowSelfSignedCertificate();

            return builder;
        }
    }
}
