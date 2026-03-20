using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Features.GetOrdersByCustomerId;

namespace Ordering.Infrastructure.Router.GetOrdersByCustomerId;

//- Accepts a customer ID.
//- Uses a GetOrdersByCustomerQuery to fetch orders.
//- Returns the list of orders for that customer.

//public record GetOrdersByCustomerRequest(Guid CustomerId);
public record Response(IEnumerable<OrderDto> Orders);

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/orders/customer/{customerId}",
                async (Guid customerId, ISender sender) =>
                {
                    var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

                    var response = result.ToResponse();

                    return Results.Ok(response);
                }
            )
            .WithName("GetOrdersByCustomer")
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Customer")
            .WithDescription("Get Orders By Customer");
    }

    public static Response ToResponse(this GetOrdersByCustomerResult orders)
    {
        return new Response(orders.Orders);
    }
}
