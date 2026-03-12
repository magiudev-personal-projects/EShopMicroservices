using Microsoft.AspNetCore.Builder;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder app)
    {
        return app;
    }
}
