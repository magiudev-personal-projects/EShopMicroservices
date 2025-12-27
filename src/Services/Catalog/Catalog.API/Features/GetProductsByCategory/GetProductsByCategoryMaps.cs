namespace Catalog.API.Features.GetProductsByCategory;

public static class GetProductsByCategoryMaps
{
    public static GetProductsByCategoryResponse FromResultToResponse(GetProductsByCategoryResult result)
    {
        return new GetProductsByCategoryResponse(result.products);
    }
}