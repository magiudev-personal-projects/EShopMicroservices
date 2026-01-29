using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Features.UpdateProduct;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/Products/{Id}",
                async ([FromBody] Request request, [FromRoute] Guid Id, ISender sender) =>
                {
                    var command = Maps.FromRequestToCommand(Id, request);
                    var result = await sender.Send(command);
                    var response = Maps.FromResultToResponse(result);
                    return Results.Ok(response);
                }
            )
            .WithName("UpdateProduct")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }
}
