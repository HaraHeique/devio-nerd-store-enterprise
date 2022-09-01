using NSE.Bff.Compras.Models;
using NSE.Bff.Compras.Models.Carrinho;
using NSE.Core.Communication;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<VoucherDTO?> ObterVoucherPorCodigo(string codigo);

        Task<ResponseResult> FinalizarPedido(PedidoDTO pedido);
        Task<PedidoDTO> ObterUltimoPedido();
        Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId();
    }
}