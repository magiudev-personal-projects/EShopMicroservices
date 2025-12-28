using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.GetProductById;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{Id}", async ([FromRoute] Guid Id, ISender sender) =>
        {
            var query = new Query(Id);

            var result = await sender.Send(query);

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = Maps.FromResultToResponse(result);

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<Response>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get product by id")
        .WithDescription("Get product by id");
    }
}
