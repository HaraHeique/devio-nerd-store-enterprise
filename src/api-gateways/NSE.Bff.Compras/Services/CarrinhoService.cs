using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Models.Carrinho;
using NSE.Bff.Compras.Options;
using NSE.Bff.Compras.Services.Interfaces;
using NSE.Core.Communication;

namespace NSE.Bff.Compras.Services
{
    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }

        public async Task<CarrinhoDTO> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoDTO>(response);
        }

        public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto)
        {
            var response = await _httpClient.PostAsync("/carrinho", ObterConteudo(produto));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AplicarVoucherCarrinho(VoucherDTO voucher)
        {
            //var response = await _httpClient.("/carrinho", ObterConteudo(voucher));

            //if (!TratarErrosResponse(response))
            //    return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO carrinho)
        {
            var response = await _httpClient.PutAsync($"/carrinho/{produtoId}", ObterConteudo(carrinho));

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }
    }
}