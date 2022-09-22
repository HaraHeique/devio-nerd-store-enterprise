using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Middlewares;
using NSE.WebApp.MVC.Options;

namespace NSE.WebApp.MVC.Configurations
{
    public static class WebAppConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            // Essa configuração é para ser utilizada junto com uso do load balance usando ngnix
            // ASP.NET gera uma chave única para que a aplicação tenha uma criptografia própria para que valide os tokens e afins
            // Com isso cada instancia vai gerar sua chave, mas como todas possuem um mesmo nome (ApplicationName) acaba que usam o mesmo padrão de chave
            // Para que os containers (N instancias) compartilhem das mesmas chaves é usado um volume nomeado compartilhado entre eles
            services.AddDataProtection()
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo("/var/data-protection-keys/"))
                .SetApplicationName("NerdStoreEnterprise");

            // Configuração dos header de forward para usar junto ao nginx e a aplicação entender que está sendo usado um proxy reverso
            // XForwardedFor: mantém os dados do chamador original, ou seja, o client
            // XForwardedProto: mantém o scheme, ou seja, se é http ou https
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.Configure<AppSettings>(configuration);

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            // Para utilização do nginx como proxy reverso
            app.UseForwardedHeaders();

            // Não sei qual erro foi e não foi pegado no catch do ExceptionMiddleware (não foi tratado)
            app.UseExceptionHandler("/erro/500");

            // Quando o erro é conhecido por ter sido tratado
            app.UseStatusCodePagesWithRedirects("/erro/{0}");

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Catalogo}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
