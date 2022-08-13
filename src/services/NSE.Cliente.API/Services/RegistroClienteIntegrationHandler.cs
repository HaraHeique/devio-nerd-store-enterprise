using FluentValidation.Results;
using NSE.Cliente.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.Core.Messages.Integration;
using NSE.Infra.MessageBus;

namespace NSE.Cliente.API.Services
{
    public class RegistroClienteIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroClienteIntegrationHandler(
            IServiceProvider serviceProvider,
            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();

            return Task.CompletedTask;
        }

        private void SetResponder()
        {
            // Usa o padrão REQUEST/RESPONSE-REPLY
            _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
            {
                var validationResult = await RegistrarCliente(request);

                return new ResponseMessage(validationResult);
            });

            //_bus.AdvancedBus.Connected += OnConnect;
        }

        // Não foi necessário usar este método na reconexão
        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ValidationResult> RegistrarCliente(UsuarioRegistradoIntegrationEvent mensagem)
        {
            using var scope = _serviceProvider.CreateScope();
            var mediadorHandler = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();

            return await mediadorHandler.EnviarComando(
                new RegistrarClienteCommand(mensagem.Id, mensagem.Nome, mensagem.Email, mensagem.Cpf)
            );
        }
    }
}
