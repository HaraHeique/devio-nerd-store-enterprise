using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Models.Carrinho;
using NSE.WebApp.MVC.Options;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Services
{
    public class CarrinhoService : BaseService, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
            _httpClient = httpClient;
        }

        public async Task<CarrinhoViewModel> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoViewModel>(response);
        }

        public async Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemProdutoViewModel produto)
        {
            var response = await _httpClient.PostAsync("/carrinho", ObterConteudo(produto));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return ReturnoOk();
        }

        public async Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto)
        {
            var response = await _httpClient.PutAsync($"/carrinho/{produtoId}", ObterConteudo(produto));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return ReturnoOk();
        }

        public async Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return ReturnoOk();
        }
    }
}
