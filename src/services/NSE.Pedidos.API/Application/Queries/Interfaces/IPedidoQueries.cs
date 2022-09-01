using NSE.Pedidos.API.Application.DTO;

namespace NSE.Pedidos.API.Application.Queries.Interfaces
{
    public interface IPedidoQueries
    {
        Task<PedidoDTO> ObterUltimoPedido(Guid clientId);
        Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clientId);
    }
}
