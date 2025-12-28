using Catalog.API.Features.CreateProduct;
using Catalog.API.Features.GetProducts;
using Catalog.API.Features.GetProductsByCategory;
using Catalog.API.Features.UpdateProduct;

namespace Catalog.API;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.UseCreateProductRoute();
        app.UseGetProductsRoute();
        app.UseGetProductByIdRoute();
        app.UseGetProductsByCategoryRoute();
        app.UseUpdateProductRoute();
    }
}
