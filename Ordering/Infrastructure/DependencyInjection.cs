using Microsoft.EntityFrameworkCore;

// using Ordering.Infrastructure.Interceptors;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder app)
    {
        var configuration = app.Configuration;
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found."
            );
        app.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            // options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseSqlServer(connectionString);
        });
        return app;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}
