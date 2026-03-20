using CreateOrder = Ordering.Infrastructure.Router.CreateOrder.Router;
using DeleteOrder = Ordering.Infrastructure.Router.DeleteOrder.Router;
using GetOrders = Ordering.Infrastructure.Router.GetOrders.Router;
using GetOrdersByCustomerId = Ordering.Infrastructure.Router.GetOrdersByCustomerId.Router;
using GetOrdersByName = Ordering.Infrastructure.Router.GetOrdersByName.Router;
using UpdateOrder = Ordering.Infrastructure.Router.UpdateOrder.Router;

namespace Ordering.Infrastructure.Routers;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        CreateOrder.AddRoute(app);
        DeleteOrder.AddRoute(app);
        GetOrders.AddRoute(app);
        GetOrdersByCustomerId.AddRoutes(app);
        GetOrdersByName.AddRoutes(app);
        UpdateOrder.AddRoute(app);
    }
}
