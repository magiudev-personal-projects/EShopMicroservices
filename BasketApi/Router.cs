using CheckoutBasket = BasketApi.Features.CheckoutBasket.Router;
using DeleteBasket = BasketApi.Features.DeleteBasket.Router;
using GetBasketByUsernameRouter = BasketApi.Features.GetBasketByUsername.Router;
using StoreBasketRouter = BasketApi.Features.StoreBasket.Router;

namespace BasketApi;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        GetBasketByUsernameRouter.AddRoute(app);
        StoreBasketRouter.AddRoute(app);
        CheckoutBasket.AddRoute(app);
        DeleteBasket.AddRoute(app);
    }
}
