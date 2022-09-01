using NSE.Core.DomainObjects;
using NSE.Pedidos.Domain.Pedidos.Enums;
using NSE.Pedidos.Domain.Pedidos.ValueObjects;
using NSE.Pedidos.Domain.Vouchers;
using NSE.Pedidos.Domain.Vouchers.Enums;

#nullable disable
namespace NSE.Pedidos.Domain.Pedidos
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }
        public Endereco Endereco { get; private set; }

        // EF Relations
        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public Voucher Voucher { get; private set; }

        // EF Constructor
        private Pedido() { }

        public Pedido(Guid clienteId, decimal valorTotal, List<PedidoItem> pedidoItems,
            bool voucherUtilizado = false, decimal desconto = 0, Guid? voucherId = null)
        {
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            Desconto = desconto;
            VoucherUtilizado = voucherUtilizado;
            VoucherId = voucherId;
            _pedidoItems = pedidoItems;
        }

        public void AutorizarPedido() => PedidoStatus = PedidoStatus.Autorizado;

        // método Ad-hock setter
        public void AtribuirVoucher(Voucher voucher)
        {
            VoucherUtilizado = true;
            VoucherId = voucher.Id;
            Voucher = voucher;
        }

        // método Ad-hock setter
        public void AtribuirEndereco(Endereco endereco) => Endereco = endereco;

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        public void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if (Voucher.TipoDesconto == TipoDescontoVoucher.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = valor * Voucher.Percentual.Value / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }
    }
}
