namespace Catalog.API.Features.GetProducts;

public class GetProductsMaps
{
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.Products.ToList());
    }
}
