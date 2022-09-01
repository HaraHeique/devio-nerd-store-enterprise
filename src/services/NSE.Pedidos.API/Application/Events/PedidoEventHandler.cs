using MediatR;
using NSE.Core.Messages.Integration;
using NSE.Infra.MessageBus;

namespace NSE.Pedidos.API.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMessageBus _bus;

        public PedidoEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(PedidoRealizadoEvent mensagem, CancellationToken cancellationToken)
        {
            // Alguma implementação aqui depois que o pedido foi realizado (aconteceu no passado)

            await _bus.PublishAsync(new PedidoRealizadoIntegrationEvent(mensagem.ClienteId));
        }
    }
}
