using NSE.WebApp.MVC.Exceptions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public abstract class BaseService
    {
        private static readonly JsonSerializerOptions SerializerOptionsDefault = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                    throw new CustomHttpRequestException(response.StatusCode);

                case HttpStatusCode.BadRequest:
                    return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        protected StringContent ObterConteudo(object dado) 
            => new(JsonSerializer.Serialize(dado), Encoding.UTF8, "application/json");

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage response) 
            => JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), SerializerOptionsDefault);
    }
}
