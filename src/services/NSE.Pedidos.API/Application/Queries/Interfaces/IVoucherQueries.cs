using NSE.Pedidos.API.Application.DTO;

namespace NSE.Pedidos.API.Application.Queries.Interfaces
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO?> ObterVoucherPorCodigo(string codigo);
    }
}
