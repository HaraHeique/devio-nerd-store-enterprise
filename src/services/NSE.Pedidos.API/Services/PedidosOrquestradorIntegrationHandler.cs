using NSE.Core.Messages.Integration;
using NSE.Infra.MessageBus;
using NSE.Pedidos.API.Application.Queries.Interfaces;

#nullable disable
namespace NSE.Pedidos.API.Services
{
    // Usar o IHostedService é também usar o BackgroundService, mas na sua forma primitiva
    public class PedidosOrquestradorIntegrationHandler : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PedidosOrquestradorIntegrationHandler> _logger;
        private Timer _timer;

        public PedidosOrquestradorIntegrationHandler(
            ILogger<PedidosOrquestradorIntegrationHandler> logger, 
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de pedidos iniciado.");

            // Roda o método ProcessarPedidos no momento que o HostedService é startado numa recorrência de 15 em 15 sec
            _timer = new Timer(ProcessarPedidos, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de pedidos finalizado.");

            // Parando o timer para sempre
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose() => _timer.Dispose();

        private async void ProcessarPedidos(object state)
        {
            _logger.LogInformation("Processando pedidos");

            using var scope = _serviceProvider.CreateScope();
            var pedidosQueries = scope.ServiceProvider.GetRequiredService<IPedidoQueries>();
            var pedido = await pedidosQueries.ObterPedidosAutorizados();

            if (pedido is null) return;

            var bus = scope.ServiceProvider.GetService<IMessageBus>();

            var pedidoAutorizado = new PedidoAutorizadoIntegrationEvent(
                pedido.ClienteId,
                pedido.Id,
                pedido.PedidoItems.ToDictionary(p => p.ProdutoId, p => p.Quantidade)
            );

            // Publicar uma mensagem para o event bus também é uma forma de fire and forget ;)
            await bus.PublishAsync(pedidoAutorizado);

            _logger.LogInformation($"Pedido ID: {pedido.Id} foi encaminhado para baixa no estoque.");
        }
    }
}
