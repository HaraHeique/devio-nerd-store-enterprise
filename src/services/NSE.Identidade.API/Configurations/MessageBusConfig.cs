using NSE.Core.Utils;
using NSE.Infra.MessageBus;

namespace NSE.Identidade.API.Configurations
{
    public static class MessageBusConfig
    {
        public static WebApplicationBuilder AddMessageBusConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddMessageBus(builder.Configuration.GetMessageQueueConnection("MessageBus")!);

            return builder;
        }
    }
}
