using System.Reflection;
using BuildingBlocks.Behaviours;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
        });

        return builder;
    }
}
