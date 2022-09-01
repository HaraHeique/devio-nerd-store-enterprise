using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Pedidos;
using NSE.Pedidos.Domain.Pedidos.Interfaces;
using System.Data.Common;

namespace NSE.Pedidos.Infra.Data.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;

        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }

        public async Task<Pedido?> ObterPorId(Guid id) => await _context.Pedidos.FindAsync(id);

        public async Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos
                .Include(p => p.PedidoItems)
                .AsNoTracking()
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();
        }

        public void Adicionar(Pedido pedido) => _context.Pedidos.Add(pedido);

        public void Atualizar(Pedido pedido) => _context.Pedidos.Update(pedido);

        public async Task<PedidoItem?> ObterItemPorId(Guid id) 
            => await _context.PedidoItens.FindAsync(id);

        public async Task<PedidoItem?> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            return await _context.PedidoItens
                .FirstOrDefaultAsync(p => p.ProdutoId == produtoId && p.PedidoId == pedidoId);
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public void Dispose() => _context.Dispose();
    }
}