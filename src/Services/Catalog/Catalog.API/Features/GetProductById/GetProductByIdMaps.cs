using Catalog.API.Features.GetProductById;

namespace Catalog.API.Features.GetProducts;

public class GetProductByIdMaps
{
    public static Features.GetProductById.Response FromResultToResponse(Features.GetProductById.Result result)
    {
        return new Features.GetProductById.Response(result.Product);
    }
}
