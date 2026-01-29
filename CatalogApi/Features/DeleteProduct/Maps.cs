namespace CatalogApi.Features.DeleteProduct;

public static class Maps
{
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.IsDeleted);
    }
}
