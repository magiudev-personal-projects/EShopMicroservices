using MediatR;

namespace Ordering.Infrastructure.Router.DeleteOrder;

//- Accepts the order ID as a parameter.
//- Constructs a DeleteOrderCommand.
//- Sends the command using MediatR.
//- Returns a success or not found response.

//public record DeleteOrderRequest(Guid Id);
public record Response(bool IsSuccess);

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/orders/{id}",
                async (Guid Id, ISender sender) =>
                {
                    var result = await sender.Send(new DeleteOrderCommand(Id));

                    var response = result.ToResponse();

                    return Results.Ok(response);
                }
            )
            .WithName("DeleteOrder")
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Order")
            .WithDescription("Delete Order");
    }

    public static Response ToResponse(this DeleteOrderResult result)
    {
        return new Response(result.IsSuccess);
    }
}
