using NSE.Core.Communication;
using System.Net;
using System.Text;
using System.Text.Json;

#nullable disable
namespace NSE.Bff.Compras.Services
{
    public abstract class Service
    {
        private static readonly JsonSerializerOptions SerializerOptionsDefault = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json"
            );
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            return JsonSerializer.Deserialize<T>(
                await responseMessage.Content.ReadAsStringAsync(), 
                SerializerOptionsDefault
            );
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest) return false;

            response.EnsureSuccessStatusCode();

            return true;
        }

        protected ResponseResult RetornoOk() => new();
    }
}