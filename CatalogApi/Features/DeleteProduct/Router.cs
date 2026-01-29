using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Features.DeleteProduct;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/products/{Id}",
                async ([FromRoute] Guid Id, ISender sender) =>
                {
                    var command = new Command(Id);
                    var result = await sender.Send(command);
                    var response = Maps.FromResultToResponse(result);
                    return Results.Ok(response);
                }
            )
            .WithName("DeleteProduct")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}
