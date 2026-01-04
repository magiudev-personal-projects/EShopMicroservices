namespace CatalogApi.Features.GetProducts;

public class Maps
{
    public static Query FromRequestToQuery(Request request)
    {
        return new Query(request.pageNumber, request.pageSize);
    }
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.Products);
    }
}
