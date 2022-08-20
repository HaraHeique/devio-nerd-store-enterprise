using System;
using System.Threading.Tasks;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Models.Carrinho;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface ICarrinhoService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemProdutoViewModel produto);
        Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
        Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId);
    }
}