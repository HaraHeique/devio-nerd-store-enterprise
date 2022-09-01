using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Models.Carrinho;
using NSE.WebApp.MVC.Models.Pedido;
using NSE.WebApp.MVC.Options;
using NSE.WebApp.MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class ComprasBffService : BaseService, IComprasBffService
    {
        private readonly HttpClient _httpClient;

        public ComprasBffService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.ComprasBffUrl);
            _httpClient = httpClient;
        }

        public async Task<CarrinhoViewModel> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoViewModel>(response);
        }
        
        public async Task<int> ObterQuantidadeCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho-quantidade");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemCarrinhoViewModel produto)
        {
            var response = await _httpClient.PostAsync("/compras/carrinho/itens", ObterConteudo(produto));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }

        public async Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto)
        {
            var response = await _httpClient.PutAsync($"/compras/carrinho/itens/{produtoId}", ObterConteudo(produto));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }

        public async Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/compras/carrinho/itens/{produtoId}");

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }

        public async Task<ResponseResultViewModel> AplicarVoucherCarrinho(string voucher)
        {
            var response = await _httpClient.PostAsync("/compras/carrinho/aplicar-voucher", ObterConteudo(voucher));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }

        public PedidoTransacaoViewModel MapearParaPedido(CarrinhoViewModel carrinho, EnderecoViewModel endereco)
        {
            var pedido = new PedidoTransacaoViewModel
            {
                ValorTotal = carrinho.ValorTotal,
                Itens = carrinho.Itens,
                Desconto = carrinho.Desconto,
                VoucherUtilizado = carrinho.VoucherUtilizado,
                VoucherCodigo = carrinho.Voucher?.Codigo
            };

            if (endereco != null)
            {
                pedido.Endereco = new EnderecoViewModel
                {
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero,
                    Bairro = endereco.Bairro,
                    Cep = endereco.Cep,
                    Complemento = endereco.Complemento,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado
                };
            }

            return pedido;
        }

        public async Task<ResponseResultViewModel> FinalizarPedido(PedidoTransacaoViewModel pedidoTransacao)
        {
            var pedidoContent = ObterConteudo(pedidoTransacao);

            var response = await _httpClient.PostAsync("/compras/pedido/", pedidoContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }

        public async Task<PedidoViewModel> ObterUltimoPedido()
        {
            var response = await _httpClient.GetAsync("/compras/pedido/ultimo/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PedidoViewModel>(response);
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterListaPorClienteId()
        {
            var response = await _httpClient.GetAsync("/compras/pedido/lista-cliente/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<PedidoViewModel>>(response);
        }
    }
}
