using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Models.Carrinho;
using NSE.WebApp.MVC.Models.Pedido;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface IComprasBffService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<int> ObterQuantidadeCarrinho();
        Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemCarrinhoViewModel produto);
        Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto);
        Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResultViewModel> AplicarVoucherCarrinho(string voucher);

        PedidoTransacaoViewModel MapearParaPedido(CarrinhoViewModel carrinho, EnderecoViewModel endereco);
        Task<ResponseResultViewModel> FinalizarPedido(PedidoTransacaoViewModel pedidoTransacao);
        Task<PedidoViewModel> ObterUltimoPedido();
        Task<IEnumerable<PedidoViewModel>> ObterListaPorClienteId();
    }
}