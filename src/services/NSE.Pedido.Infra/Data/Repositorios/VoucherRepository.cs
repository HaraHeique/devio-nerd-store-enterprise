using NSE.Core.Data;
using NSE.Pedido.Domain.Vouchers;

namespace NSE.Pedido.Infra.Data.Repositorios
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidoContext _context;

        public VoucherRepository(PedidoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose() => _context.Dispose();
    }
}