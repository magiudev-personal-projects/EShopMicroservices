using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.UpdateProduct;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapPut("/Products", async ([FromBody] Request request, ISender sender) =>
        {
           var command = Maps.FromRequestToCommand(request);
           var result = await sender.Send(command);
           var response = Maps.FromResultToResponse(result);
           return response;
        })
            .WithName("Update Product")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Update Product");
    }
}