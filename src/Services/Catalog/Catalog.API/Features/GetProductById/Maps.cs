namespace Catalog.API.Features.GetProductById;

public class Maps
{
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.Product);
    }
}
