using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Options;
using NSE.Bff.Compras.Services.Interfaces;

namespace NSE.Bff.Compras.Services
{
    public class PedidoService : Service, IPedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PedidoUrl);
        }
    }
}