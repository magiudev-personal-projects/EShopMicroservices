using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Features.GetBasketByUsername;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/baskets/{userName}",
                async ([FromRoute] string userName, ISender sender) =>
                {
                    var query = new Query(userName);

                    var result = await sender.Send(query);

                    var response = Maps.FromResultToResponse(result);

                    return Results.Ok(response);
                }
            )
            .WithName("GetBasketByUsername")
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get basket by username")
            .WithDescription("Get basket by username");
    }
}
