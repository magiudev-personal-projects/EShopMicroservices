namespace BasketApi.Features.DeleteBasket;

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/baskets/{userName}",
                async (string userName, ISender sender) =>
                {
                    var command = new Command(userName);

                    var result = await sender.Send(command);

                    var response = Maps.FromResultToResult(result);

                    return Results.Ok(response);
                }
            )
            .WithName("DeleteProduct")
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}
