using Microsoft.Extensions.DependencyInjection;

namespace NSE.WebAPI.Core.Extensions
{
    public static class HttpExtensions
    {
        public static IHttpClientBuilder AllowSelfSignedCertificate(this IHttpClientBuilder builder)
        {
            // Para habilitar certificados gerados por self signed (localhost certificates)

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.ConfigureHttpMessageHandlerBuilder(b =>
            {
                b.PrimaryHandler =
                    new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
            });
        }
    }
}
