namespace Catalog.API.Features.GetProductsByCategory;

public static class GetProductsByCategoryMaps
{
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.products);
    }
}