using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Core.Messages.Integration;
using NSE.Infra.MessageBus;
using NSE.Pedidos.API.Application.DTO;
using NSE.Pedidos.API.Application.Events;
using NSE.Pedidos.Domain.Pedidos;
using NSE.Pedidos.Domain.Pedidos.Interfaces;
using NSE.Pedidos.Domain.Pedidos.ValueObjects;
using NSE.Pedidos.Domain.Vouchers.Interfaces;
using NSE.Pedidos.Domain.Vouchers.Validations;

namespace NSE.Pedidos.API.Application.Commands
{
    public class PedidoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarPedidoCommand, ValidationResult>
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMessageBus _bus;

        public PedidoCommandHandler(
            IVoucherRepository voucherRepository,
            IPedidoRepository pedidoRepository, 
            IMessageBus bus)
        {
            _voucherRepository = voucherRepository;
            _pedidoRepository = pedidoRepository;
            _bus = bus;
        }

        public async Task<ValidationResult> Handle(AdicionarPedidoCommand mensagem, CancellationToken cancellationToken)
        {
            // Validação do comando
            if (!mensagem.EhValido()) return mensagem.ValidationResult;

            // Mapear pedido
            var pedido = MapearPedido(mensagem);

            // Aplicar voucher se houver
            if (!await AplicarVoucher(mensagem, pedido)) return ValidationResult;

            // Validar pedido (verificar o valor total e desconto do pedido bate com do carrinho que é o que veio do AdicionarPedidoCommand) 
            if (!ValidarPedido(pedido)) return ValidationResult;

            // Processar pagamento
            if (!await ProcessarPagamento(pedido, mensagem)) return ValidationResult;

            // Se pagamento tá tudo ok!
            pedido.AutorizarPedido();

            // Adicionar evento
            pedido.AdicionarEvento(new PedidoRealizadoEvent(pedido.Id, pedido.ClienteId));

            // Adicionar pedido repositório
            _pedidoRepository.Adicionar(pedido);

            // Persistir dados de pedido e voucher
            return await PersistirDados(_pedidoRepository.UnitOfWork);
        }

        private Pedido MapearPedido(AdicionarPedidoCommand messagem)
        {
            var endereco = new Endereco
            {
                Logradouro = messagem.Endereco.Logradouro,
                Numero = messagem.Endereco.Numero,
                Complemento = messagem.Endereco.Complemento,
                Bairro = messagem.Endereco.Bairro,
                Cep = messagem.Endereco.Cep,
                Cidade = messagem.Endereco.Cidade,
                Estado = messagem.Endereco.Estado
            };

            var pedido = new Pedido(
                messagem.ClienteId, messagem.ValorTotal, 
                messagem.PedidoItems.Select(PedidoItemDTO.ParaPedidoItem).ToList(),
                messagem.VoucherUtilizado, messagem.Desconto
            );

            pedido.AtribuirEndereco(endereco);

            return pedido;
        }

        private async Task<bool> AplicarVoucher(AdicionarPedidoCommand message, Pedido pedido)
        {
            if (!message.VoucherUtilizado) return true;

            var voucher = await _voucherRepository.ObterVoucherPorCodigo(message.VoucherCodigo);
            
            if (voucher is null)
            {
                AdicionarErro("O voucher informado não existe!");
                return false;
            }

            var voucherValidation = new VoucherValidation().Validate(voucher);
            
            if (!voucherValidation.IsValid)
            {
                voucherValidation.Errors.ToList().ForEach(m => AdicionarErro(m.ErrorMessage));
                return false;
            }

            pedido.AtribuirVoucher(voucher);
            voucher.DebitarQuantidade();

            _voucherRepository.Atualizar(voucher);

            return true;
        }

        private bool ValidarPedido(Pedido pedido)
        {
            var pedidoValorOriginal = pedido.ValorTotal;
            var pedidoDesconto = pedido.Desconto;

            pedido.CalcularValorPedido();

            if (pedido.ValorTotal != pedidoValorOriginal)
            {
                AdicionarErro("O valor total do pedido não confere com o cálculo do pedido");
                return false;
            }

            if (pedido.Desconto != pedidoDesconto)
            {
                AdicionarErro("O valor total não confere com o cálculo do pedido");
                return false;
            }

            return true;
        }

        private async Task<bool> ProcessarPagamento(Pedido pedido, AdicionarPedidoCommand mensagem)
        {
            var pedidoIniciado = new PedidoIniciadoIntegrationEvent
            {
                PedidoId = pedido.Id,
                ClienteId = pedido.ClienteId,
                Valor = pedido.ValorTotal,
                TipoPagamento = 1, // fixo. Alterar se tiver mais tipos
                NomeCartao = mensagem.NomeCartao,
                NumeroCartao = mensagem.NumeroCartao,
                MesAnoVencimento = mensagem.ExpiracaoCartao,
                CVV = mensagem.CvvCartao
            };

            var resultado = await _bus.RequestAsync<PedidoIniciadoIntegrationEvent, ResponseMessage>(pedidoIniciado);

            if (resultado.ValidationResult.IsValid) return true;

            AdicionarErros(ValidationResult.Errors);

            return false;
        }
    }
}
