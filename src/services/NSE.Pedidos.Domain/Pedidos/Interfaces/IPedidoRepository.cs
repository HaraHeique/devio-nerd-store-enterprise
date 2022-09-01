using NSE.Core.Data;
using System.Data.Common;

namespace NSE.Pedidos.Domain.Pedidos.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido?> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);

        // Pedido Item (é uma agregação de Pedido por isso junto a ele)
        Task<PedidoItem?> ObterItemPorId(Guid id);
        Task<PedidoItem?> ObterItemPorPedido(Guid pedidoId, Guid produtoId);

        // Conexão para uso do Dapper nas QueriesStackes/QueriesHandlers
        DbConnection ObterConexao();
    }
}
