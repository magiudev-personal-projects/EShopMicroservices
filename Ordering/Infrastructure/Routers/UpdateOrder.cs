using MediatR;
using Ordering.Application.Dtos;

namespace Ordering.Infrastructure.Router.UpdateOrder;

public record Request(OrderDto Order);

public record Response(bool IsSuccess);

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/orders",
                async (Request request, ISender sender) =>
                {
                    var command = request.ToCommand();

                    var result = await sender.Send(command);

                    var response = result.ToResponse();

                    return Results.Ok(response);
                }
            )
            .WithName("UpdateOrder")
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Order")
            .WithDescription("Update Order");
    }

    public static UpdateOrderCommand ToCommand(this Request request)
    {
        return new UpdateOrderCommand(request.Order);
    }

    public static Response ToResponse(this UpdateOrderResult result)
    {
        return new Response(result.IsSuccess);
    }
}
