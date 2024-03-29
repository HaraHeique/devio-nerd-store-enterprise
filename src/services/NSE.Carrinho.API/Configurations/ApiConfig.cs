﻿using Microsoft.AspNetCore.Mvc;
using NSE.Carrinho.API.Services.gRPC;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Carrinho.API.Configurations
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddGrpc();

            builder.Services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AcessoTotal", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return builder;
        }

        public static WebApplication UseApiConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AcessoTotal");

            app.UseAuthConfiguration();

            app.MapControllers();
            app.MapGrpcService<CarrinhoGrpcService>().RequireCors("AcessoTotal");

            return app;
        }
    }
}
