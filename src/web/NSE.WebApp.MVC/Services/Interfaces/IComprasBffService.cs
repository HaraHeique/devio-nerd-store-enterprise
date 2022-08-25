using System;
using System.Threading.Tasks;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Models.Carrinho;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface IComprasBffService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<int> ObterQuantidadeCarrinho();
        Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemCarrinhoViewModel produto);
        Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto);
        Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId);
    }
}