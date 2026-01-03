namespace CatalogApi.Features.CreateProduct;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (Request request, ISender sender) =>
        {
            var command = Maps.FromRequestToCommand(request);

            var result = await sender.Send(command);

            var response = Maps.FromResultToResponse(result);

            return Results.CreatedAtRoute("GetProductById", new { response.Id }, response);
        })
        .WithName("CreateProduct")
        .Produces<Response>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Crete a product")
        .WithDescription("Crete a product");
    }
}