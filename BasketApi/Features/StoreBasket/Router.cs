using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Features.StoreBasket;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapPost("/baskets", async ([FromBody] Request request, ISender sender) =>
        {
            var command = Maps.FromRequestToCommand(request);

            var result = await sender.Send(command);

            var response = Maps.FromResultToResponse(result);

            return Results.CreatedAtRoute("GetBasketByUsername", new { response.UserName }, response);
        })
            .WithName("StoreBasket")
            .Produces<Response>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Store Basket")
            .WithDescription("Store Basket");
    }
}