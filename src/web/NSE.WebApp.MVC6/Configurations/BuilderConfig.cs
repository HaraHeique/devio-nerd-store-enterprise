namespace NSE.WebApp.MVC.Configurations
{
    public static class BuilderConfig
    {
        public static IConfiguration Build(this ConfigurationManager builderManager, IWebHostEnvironment env)
        {
            var builder = builderManager
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddUserSecrets<Program>();

            return builder.Build();
        }
    }
}
