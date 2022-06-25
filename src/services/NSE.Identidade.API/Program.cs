using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSE.Identidade.API.Data;

namespace NSE.Identidade.API
{
    #pragma warning disable
    public class Program
    {
        private static WebApplicationBuilder _builder;
        private static WebApplication _app;

        public static void Main(string[] args)
        {
            // ConfigureServices (Add services to the container)
            _builder = WebApplication.CreateBuilder(args);

            ConfigureServices();

            // Configure (Configure the HTTP request pipeline)
            _app = _builder.Build();

            ConfigureRequestsPipeline();
        }

        private static void ConfigureServices()
        {
            IServiceCollection services = _builder.Services;
            IConfiguration configuration = _builder.Configuration;

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void ConfigureRequestsPipeline()
        {
            if (_app.Environment.IsDevelopment())
            {
                _app.UseSwagger();
                _app.UseSwaggerUI();
            }

            _app.UseHttpsRedirection();

            _app.UseAuthentication();
            _app.UseAuthorization();

            _app.MapControllers();

            _app.Run();
        }
    }
}