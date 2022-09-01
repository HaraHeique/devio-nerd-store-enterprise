using NSE.Bff.Compras.Models;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface IClienteService
    {
        Task<EnderecoDTO> ObterEndereco();
    }
}