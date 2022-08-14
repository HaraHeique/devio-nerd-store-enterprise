namespace NSE.Carrinho.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<CatalogoContext>();
            //builder.Services.AddDbContext<CatalogoContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            //);

            //builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return builder;
        }
    }
}
