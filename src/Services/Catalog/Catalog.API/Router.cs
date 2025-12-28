using CreateProductRouter = Catalog.API.Features.CreateProduct.Router;
using GetProductByIdRouter = Catalog.API.Features.GetProductById.Router;
using GetProductsRouter = Catalog.API.Features.GetProducts.Router;
using GetProductsByCategoryRouter = Catalog.API.Features.GetProductsByCategory.Router;
using UpdateProductRouter = Catalog.API.Features.UpdateProduct.Router;
using DeleteProductRouter = Catalog.API.Features.DeleteProduct.Router;

namespace Catalog.API;

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
