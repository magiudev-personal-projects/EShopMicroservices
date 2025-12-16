using Catalog.API.Features.GetProductById;

namespace Catalog.API.Features.GetProducts;

public class GetProductByIdMaps
{
    public static GetProductByIdResponse FromResultToResponse(GetProductByIdResult result)
    {
        return new GetProductByIdResponse(result.Product);
    }
}
