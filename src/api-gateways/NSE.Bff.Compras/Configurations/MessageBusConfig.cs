﻿using NSE.Core.Utils;
using NSE.Infra.MessageBus;

namespace NSE.Bff.Compras.Configurations
{
    public static class MessageBusConfig
    {
        public static WebApplicationBuilder AddMessageBusConfiguration(this WebApplicationBuilder builder)
        {
            // OBS.: Todo hosted service tem injeção de dependência singleton. Logo não pode injetar nada nele que não seja singleton

            //builder.Services.AddMessageBus(builder.Configuration.GetMessageQueueConnection("MessageBus")!)
            //    .AddHostedService<RegistroClienteIntegrationHandler>();

            return builder;
        }
    }
}
