using NSE.WebApp.MVC.Configurations;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container

builder.Configuration.Build(builder.Environment);

builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterDependencies();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline

app.UseMvcConfiguration();
app.UseGlobalizationConfiguration();

#endregion

await app.RunAsync();
