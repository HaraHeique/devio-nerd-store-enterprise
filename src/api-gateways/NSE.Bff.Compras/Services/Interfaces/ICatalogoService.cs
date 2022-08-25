using NSE.Bff.Compras.Models;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface ICatalogoService
    {
        Task<ItemProdutoDTO> ObterPorId(Guid id);
        Task<IEnumerable<ItemProdutoDTO>> ObterItens(IEnumerable<Guid> ids);
    }
}