using Microsoft.EntityFrameworkCore;
using NSE.Pagamentos.API.Data;
using NSE.Pagamentos.API.Data.Repository;
using NSE.Pagamentos.API.Facade;
using NSE.Pagamentos.API.Models;
using NSE.Pagamentos.API.Services;
using NSE.WebAPI.Core.Usuario;

namespace NSE.Pagamentos.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PagamentosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IAspNetUser, AspNetUser>();

            builder.Services.AddScoped<IPagamentoService, PagamentoService>();
            builder.Services.AddScoped<IPagamentoFacade, PagamentoCartaoCreditoFacade>();

            builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();

            return builder;
        }
    }
}
