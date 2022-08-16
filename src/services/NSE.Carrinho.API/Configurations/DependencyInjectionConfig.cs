using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.API.Data;

namespace NSE.Carrinho.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CarrinhoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            //builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return builder;
        }
    }
}
