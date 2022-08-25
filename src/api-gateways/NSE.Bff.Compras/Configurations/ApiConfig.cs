using Microsoft.AspNetCore.Mvc;
using NSE.Bff.Compras.Options;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Bff.Compras.Configurations
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.Configure<AppServiceSettings>(builder.Configuration);
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

            return app;
        }
    }
}
