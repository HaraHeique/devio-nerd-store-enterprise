using NSE.Bff.Compras.Services;
using NSE.Bff.Compras.Services.Interfaces;
using NSE.WebAPI.Core.Usuario;
using NSE.WebApp.MVC.DelegatingHandlers;
using NSE.WebApp.MVC.Extensions;

namespace NSE.Bff.Compras.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IAspNetUser, AspNetUser>();

            builder.Services.RegisterHttpServices();

            return builder;
        }

        private static void RegisterHttpServices(this IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(PollyExtensions.QuebrarCircuito());

            services.AddHttpClient<ICarrinhoService, CarrinhoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(PollyExtensions.QuebrarCircuito());
        }
    }
}
