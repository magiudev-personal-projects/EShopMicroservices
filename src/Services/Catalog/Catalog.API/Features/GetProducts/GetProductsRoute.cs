namespace Catalog.API.Features.GetProducts;

public static class GetProducts
{
    public static void UseGetProductsRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = new Query();

            var result = await sender.Send(query);

            var response = Maps.FromResultToResponse(result);

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<Response>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get all products")
        .WithDescription("Get all products");
    }
}
