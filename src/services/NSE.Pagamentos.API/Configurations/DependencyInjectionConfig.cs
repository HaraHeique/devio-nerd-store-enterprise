using Microsoft.EntityFrameworkCore;
using NSE.Pagamentos.API.Data;

namespace NSE.Pagamentos.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PagamentosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            //builder.Services.AddHttpContextAccessor();
            //builder.Services.AddScoped<IAspNetUser, AspNetUser>();

            return builder;
        }
    }
}
