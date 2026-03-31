using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

var reverseProxy = builder.Configuration.GetSection("ReverseProxy");

builder.Services.AddReverseProxy().LoadFromConfig(reverseProxy);

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(
        "fixed",
        opt =>
        {
            opt.PermitLimit = 5;
            opt.Window = TimeSpan.FromSeconds(10);
        }
    );
});

var app = builder.Build();

app.UseRateLimiter();

app.MapReverseProxy();

app.Run();
