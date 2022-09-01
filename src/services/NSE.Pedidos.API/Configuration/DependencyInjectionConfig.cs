using MediatR;
using Microsoft.EntityFrameworkCore;
using NSE.Core.Mediator;
using NSE.Pedidos.API.Application.Queries;
using NSE.Pedidos.API.Application.Queries.Interfaces;
using NSE.Pedidos.Domain.Pedidos.Interfaces;
using NSE.Pedidos.Domain.Vouchers.Interfaces;
using NSE.Pedidos.Infra.Data;
using NSE.Pedidos.Infra.Data.Repositorios;
using NSE.WebAPI.Core.Usuario;
using System.Reflection;

namespace NSE.Pedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            // API
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IAspNetUser, AspNetUser>();

            // Application
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

            builder.Services.AddScoped<IVoucherQueries, VoucherQueries>();
            builder.Services.AddScoped<IPedidoQueries, PedidoQueries>();

            //services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            //services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            // Data
            //builder.Services.AddScoped<PedidoContext>();
            builder.Services.AddDbContext<PedidoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

            return builder;
        }
    }
}
