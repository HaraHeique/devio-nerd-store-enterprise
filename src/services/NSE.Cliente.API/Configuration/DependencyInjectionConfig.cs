using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSE.Cliente.API.Application.Commands;
using NSE.Cliente.API.Application.Events;
using NSE.Cliente.API.Data;
using NSE.Cliente.API.Data.Repositorios;
using NSE.Cliente.API.Models;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Usuario;
using System.Reflection;

namespace NSE.Cliente.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<ClientesContext>();
            builder.Services.AddDbContext<ClientesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Não há necessidade dessa duas linhas abaixo porque o AddMediatR já resolve a dependência desses recursos automaticamente
            //builder.Services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            //builder.Services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IAspNetUser, AspNetUser>();

            return builder;
        }
    }
}
