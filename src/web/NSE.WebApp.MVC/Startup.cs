using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Configurations;

namespace NSE.WebApp.MVC
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env) => Configuration = new ConfigurationBuilder().Build(env);

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration();

            services.AddMvcConfiguration(Configuration);

            services.RegisterDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvcConfiguration(env);

            app.UseGlobalizationConfiguration();
        }
    }
}
