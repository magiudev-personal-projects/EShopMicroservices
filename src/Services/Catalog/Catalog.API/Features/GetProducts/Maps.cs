namespace Catalog.API.Features.GetProducts;

public class Maps
{
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.Products.ToList());
    }
}
