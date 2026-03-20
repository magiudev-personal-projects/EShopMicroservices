using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Features.GetOrderByUsername;

namespace Ordering.Infrastructure.Router.GetOrdersByName;

//- Accepts a name parameter.
//- Constructs a GetOrdersByNameQuery.
//- Retrieves and returns matching orders.

//public record GetOrdersByNameRequest(string Name);
public record Response(IEnumerable<OrderDto> Orders);

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/orders/{orderName}",
                async (string orderName, ISender sender) =>
                {
                    var result = await sender.Send(new GetOrdersByNameQuery(orderName));

                    var response = result.ToResponse();

                    return Results.Ok(response);
                }
            )
            .WithName("GetOrdersByName")
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Name")
            .WithDescription("Get Orders By Name");
    }

    public static Response ToResponse(this GetOrdersByNameResult orders)
    {
        return new Response(orders.Orders);
    }
}
