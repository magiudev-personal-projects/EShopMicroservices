namespace CatalogApi.Features.GetProducts;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender, [AsParameters] Request request) =>
        {
            var query = new Query(request.pageNumber, request.pageSize);

            var result = await sender.Send(query);

            var response = Maps.FromResultToResponse(result);

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<Response>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get all products")
        .WithDescription("Get all products");
    }
}
