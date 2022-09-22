using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace NSE.WebApp.MVC.Extensions
{
    public static class HttpExtensions
    {
        // Para habilitar certificados gerados por self signed (localhost certificates)
        public static IHttpClientBuilder AllowSelfSignedCertificate(this IHttpClientBuilder builder)
        {
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
