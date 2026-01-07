
using GetBasketByUsernameRouter = BasketApi.Features.GetBasketByUsername.Router;
using StoreBasketRouter = BasketApi.Features.StoreBasket.Router;

namespace BasketApi;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        GetBasketByUsernameRouter.AddRoute(app);
        StoreBasketRouter.AddRoute(app);
    }
}

