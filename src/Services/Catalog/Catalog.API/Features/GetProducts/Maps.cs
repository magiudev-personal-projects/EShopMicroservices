namespace Catalog.API.Features.GetProducts;

public class Maps
{
    public static Query GetQuery(Guid Id, Request request)
    {
        return new Query(request.pageNumber, request.pageSize);
    }
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.Products.ToList());
    }
}
