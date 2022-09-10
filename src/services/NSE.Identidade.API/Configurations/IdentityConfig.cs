using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSE.Identidade.API.Data;
using NSE.Identidade.API.Extensions;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Identidade.API.Configurations
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
        {
            // Definindo o algoritmo de forma aleatória para gerar a chave e definindo o local onde será persistido as chaves
            builder.Services.AddJwksManager()
                .PersistKeysToDatabaseStore<ApplicationDbContext>();

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityTranslateErrorsExtensions>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Como essa API só emite tokens não preciso dessa configuração que é para validá-lo/entende-lo
            //builder.AddJwtConfiguration();

            return builder;
        }
    }
}
