using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Net.Http;

namespace NSE.WebApp.MVC.Extensions
{
    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError() // Funciona para os status code 5XX, 408 (timeout) e falhas em networks
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });
        }

        public static Func<PolicyBuilder<HttpResponseMessage>, IAsyncPolicy<HttpResponseMessage>> QuebrarCircuito()
        {
            return p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }
    }
}
