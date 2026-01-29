using CreateProductRouter = CatalogApi.Features.CreateProduct.Router;
using DeleteProductRouter = CatalogApi.Features.DeleteProduct.Router;
using GetProductByIdRouter = CatalogApi.Features.GetProductById.Router;
using GetProductsByCategoryRouter = CatalogApi.Features.GetProductsByCategory.Router;
using GetProductsRouter = CatalogApi.Features.GetProducts.Router;
using UpdateProductRouter = CatalogApi.Features.UpdateProduct.Router;

namespace CatalogApi;

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        CreateProductRouter.AddRoute(app);
        GetProductByIdRouter.AddRoute(app);
        GetProductsRouter.AddRoute(app);
        GetProductsByCategoryRouter.AddRoute(app);
        UpdateProductRouter.AddRoute(app);
        DeleteProductRouter.AddRoute(app);
    }
}
