﻿using Microsoft.AspNetCore.Mvc.DataAnnotations;
using NSE.WebAPI.Core.Usuario;
using NSE.WebApp.MVC.DelegatingHandlers;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Interfaces;
using NSE.WebApp.MVC.ValidationAttributes;

namespace NSE.WebApp.MVC.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();

            RegisterHttpServices(services);

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }

        private static void RegisterHttpServices(IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(PollyExtensions.QuebrarCircuito());

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
