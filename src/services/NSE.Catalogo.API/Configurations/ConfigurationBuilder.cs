namespace NSE.Catalogo.API.Configurations
{
    public static class ConfigurationBuilder
    {
        public static IConfiguration SetDefaultConfig(this ConfigurationManager configManager, IWebHostEnvironment hostingEnvironment)
        {
            var builder = configManager
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostingEnvironment.IsDevelopment())
                builder.AddUserSecrets<Program>();

            return builder.Build();
        }
    }
}
