var builder = WebApplication.CreateBuilder(args);

var reverseProxy = builder.Configuration.GetSection("ReverseProxy");

builder.Services.AddReverseProxy().LoadFromConfig(reverseProxy);

var app = builder.Build();

app.MapReverseProxy();

app.Run();
