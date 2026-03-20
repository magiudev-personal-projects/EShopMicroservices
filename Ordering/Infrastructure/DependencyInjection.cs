using BuildingBlocks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Application.Data;
using Ordering.Infrastructure.Interceptors;
using Ordering.Infrastructure.Routers;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found."
            );

        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        builder.Services.AddDbContext<ApplicationDbContext>(
            (sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            }
        );

        builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        builder.Services.AddExceptionHandler<ExceptionHandler>();
        builder.Services.AddHealthChecks().AddSqlServer(connectionString);
        return builder;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.AddRoutes();
        app.UseExceptionHandler(options => { });
        app.UseHealthChecks(
            "/health",
            new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse }
        );
        return app;
    }
}
