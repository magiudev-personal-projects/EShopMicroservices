
using GetBasketByUsernameRouter = BasketApi.Features.GetBasketByUsername.Router;
using StoreBasketRouter = BasketApi.Features.StoreBasket.Router;
using CheckoutBasket = BasketApi.Features.CheckoutBasket.Router;

namespace BasketApi;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        GetBasketByUsernameRouter.AddRoute(app);
        StoreBasketRouter.AddRoute(app);
        CheckoutBasket.AddRoute(app);
    }
}

