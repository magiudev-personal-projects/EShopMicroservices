namespace Catalog.API.Features.GetProducts;

public class GetProductsMaps
{
    public static GetProductsResponse FromResultToResponse(GetProductsResult result)
    {
        return new GetProductsResponse(result.Products.ToList());
    }
}
