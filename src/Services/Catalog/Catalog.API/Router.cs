using Catalog.API.Features.CreateProduct;
using Catalog.API.Features.GetProducts;

namespace Catalog.API;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.UseCreateProductRoute();
        app.UseGetProductsRoute();
    }
}
