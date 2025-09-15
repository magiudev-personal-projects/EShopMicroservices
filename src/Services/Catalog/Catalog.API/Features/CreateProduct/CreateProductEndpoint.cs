using MediatR;

namespace Catalog.API.Features.CreateProduct;

public record CreateProductRequest(
     string Name,
     List<string> Categories,
     string Description,
     string ImageFile,
     decimal Price
);

public record CreateProductResponse(Guid Id);

public static class CreateProductEndpoint
{
    public static void UseCreateProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = CreateProductMaps.FromRequestToCommand(request);

            var result = await sender.Send(command);

            var response = CreateProductMaps.FromResultToResponse(result);

            return Results.Created($"/product/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Crete a product")
        .WithDescription("Crete a product");
    }
}