
using GetBasketByUsernameRouter = BasketApi.Features.GetBasketByUsername.Router;

namespace BasketApi;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        GetBasketByUsernameRouter.AddRoute(app);
    }
}

