namespace Catalog.API.Features.CreateProduct;

public static class CreateProductRoute
{
    public static void UseCreateProductRoute(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (Request request, ISender sender) =>
        {
            var command = Maps.FromRequestToCommand(request);

            var result = await sender.Send(command);

            var response = Maps.FromResultToResponse(result);

            return Results.Created($"/product/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<Response>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Crete a product")
        .WithDescription("Crete a product");
    }
}