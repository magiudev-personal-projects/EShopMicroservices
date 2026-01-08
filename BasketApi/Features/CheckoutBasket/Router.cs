using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Features.CheckoutBasket;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapPost("/baskets/checkout", async ([FromBody] Request request, ISender sender) =>
        {
            var command = Maps.FromRequestToCommand(request);

            var result = await sender.Send(command);

            var response = Maps.FromResultToResponse(result);

            return Results.Ok(response);
        })
        .WithName("CheckoutBasket")
        .Produces<Response>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Checkout Basket")
        .WithDescription("Checkout Basket");
    }
}