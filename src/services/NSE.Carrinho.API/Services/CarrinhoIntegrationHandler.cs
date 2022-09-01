using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.API.Data;
using NSE.Core.Messages.Integration;
using NSE.Infra.MessageBus;

namespace NSE.Carrinho.API.Services
{
    public class CarrinhoIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CarrinhoIntegrationHandler(
            IMessageBus bus,
            IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();

            return Task.CompletedTask;
        }

        private async Task SetSubscribers()
        {
            await _bus.SubscribeAsync<PedidoRealizadoIntegrationEvent>("PedidoRealizado", ApagarCarrinho);
        }

        private async Task ApagarCarrinho(PedidoRealizadoIntegrationEvent mensagem)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CarrinhoContext>();

            var carrinho = await context.CarrinhoClientes
                .FirstOrDefaultAsync(c => c.ClienteId == mensagem.ClienteId);

            if (carrinho is not null)
            {
                context.CarrinhoClientes.Remove(carrinho);
                await context.SaveChangesAsync();
            }
        }
    }
}
