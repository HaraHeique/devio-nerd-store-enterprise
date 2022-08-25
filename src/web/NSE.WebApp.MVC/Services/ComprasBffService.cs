using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Models.Carrinho;
using NSE.WebApp.MVC.Options;
using NSE.WebApp.MVC.Services.Interfaces;
using System;
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

            return ReturnoOk();
        }

        public async Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto)
        {
            var response = await _httpClient.PutAsync($"/compras/carrinho/itens/{produtoId}", ObterConteudo(produto));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return ReturnoOk();
        }

        public async Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/compras/carrinho/itens/{produtoId}");

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return ReturnoOk();
        }
    }
}
