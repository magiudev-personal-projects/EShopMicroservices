using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.DeleteProduct;

public static class Router
{
    // TODO: move logs to routes
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{Id}", async ([FromRoute] Guid Id, ISender sender) =>
        {
            var command = new Command(Id);
            var result = await sender.Send(command);
            var response = Maps.FromResultToResponse(result);
            return response;
        })
            .WithName("Delete Product")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Delete Product");        
    }
}