using NSE.Core.DomainObjects;
using NSE.Core.Messages.Integration;
using NSE.Infra.MessageBus;
using NSE.Pagamentos.API.Models;

namespace NSE.Pagamentos.API.Services
{
    public class PagamentoIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PagamentoIntegrationHandler(
            IServiceProvider serviceProvider,
            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<PedidoIniciadoIntegrationEvent, ResponseMessage>(async request =>
                await AutorizarPagamento(request));
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<PedidoCanceladoIntegrationEvent>("PedidoCancelado", async request =>
                await CancelarPagamento(request));

            _bus.SubscribeAsync<PedidoBaixadoEstoqueIntegrationEvent>("PedidoBaixadoEstoque", async request =>
                await CapturarPagamento(request));
        }

        private async Task<ResponseMessage> AutorizarPagamento(PedidoIniciadoIntegrationEvent mensagem)
        {
            using var scope = _serviceProvider.CreateScope();
            var pagamentoService = scope.ServiceProvider.GetRequiredService<IPagamentoService>();
            var pagamento = new Pagamento
            {
                PedidoId = mensagem.PedidoId,
                TipoPagamento = (TipoPagamento)mensagem.TipoPagamento,
                Valor = mensagem.Valor,
                CartaoCredito = new CartaoCredito(
                    mensagem.NomeCartao, mensagem.NumeroCartao, mensagem.MesAnoVencimento, mensagem.CVV)
            };

            var response = await pagamentoService.AutorizarPagamento(pagamento);

            return response;
        }

        private async Task CancelarPagamento(PedidoCanceladoIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var pagamentoService = scope.ServiceProvider.GetRequiredService<IPagamentoService>();

            var response = await pagamentoService.CancelarPagamento(message.PedidoId);

            if (!response.ValidationResult.IsValid)
                throw new DomainException($"Falha ao cancelar pagamento do pedido {message.PedidoId}");
        }

        private async Task CapturarPagamento(PedidoBaixadoEstoqueIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var pagamentoService = scope.ServiceProvider.GetRequiredService<IPagamentoService>();

            var response = await pagamentoService.CapturarPagamento(message.PedidoId);

            if (!response.ValidationResult.IsValid)
                throw new DomainException($"Falha ao capturar pagamento do pedido {message.PedidoId}");

            await _bus.PublishAsync(new PedidoPagoIntegrationEvent(message.ClienteId, message.PedidoId));
        }
    }
}