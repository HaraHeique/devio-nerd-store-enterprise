using Microsoft.AspNetCore.Mvc;
using NSE.Identidade.API.Services;
using NSE.WebAPI.Core.Identidade;
using NSE.WebAPI.Core.Usuario;

namespace NSE.Identidade.API.Configurations
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<IAspNetUser, AspNetUser>();

            builder.Services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);

            return builder;
        }
        
        public static WebApplication UseApiConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();

            app.MapControllers();

            // Responsável por expor o endpoint com a chave pública criada
            // Rota padrão é localhost/jwks, mas pode ser configurada
            app.UseJwksDiscovery();

            return app;
        }
    }
}
