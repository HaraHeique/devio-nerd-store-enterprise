using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Options;
using NSE.Bff.Compras.Services.Interfaces;

namespace NSE.Bff.Compras.Services
{
    public class PagamentoService : Service, IPagamentoService
    {
        private readonly HttpClient _httpClient;

        public PagamentoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PagamentoUrl);
        }
    }
}