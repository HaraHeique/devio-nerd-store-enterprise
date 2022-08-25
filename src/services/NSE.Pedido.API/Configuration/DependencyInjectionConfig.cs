using MediatR;
using Microsoft.EntityFrameworkCore;
using NSE.Core.Mediator;
using System.Reflection;

namespace NSE.Pedido.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<PedidoContext>();
            //builder.Services.AddDbContext<PedidoContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            //);

            //builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

            return builder;
        }
    }
}
