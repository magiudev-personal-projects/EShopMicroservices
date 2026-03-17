using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Application.Data;
using Ordering.Infrastructure.Interceptors;

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

        app.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        app.Services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        app.Services.AddDbContext<ApplicationDbContext>(
            (sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            }
        );

        app.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return app;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}
