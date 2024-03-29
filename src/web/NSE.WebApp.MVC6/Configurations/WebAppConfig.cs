﻿using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Middlewares;
using NSE.WebApp.MVC.Options;

namespace NSE.WebApp.MVC.Configurations
{
    public static class WebAppConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            //.AddRazorRuntimeCompilation();

            services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);

            services.Configure<AppSettings>(configuration);

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
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
