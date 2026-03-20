using BuildingBlocks.Pagination;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Features.GetOrders;

namespace Ordering.Infrastructure.Router.GetOrders;

//- Accepts pagination parameters.
//- Constructs a GetOrdersQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetOrdersRequest(PaginationRequest PaginationRequest);
public record Response(PaginatedResult<OrderDto> Orders);

public static class Router
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/orders",
                async ([AsParameters] PaginationRequest request, ISender sender) =>
                {
                    var result = await sender.Send(new GetOrdersQuery(request));

                    var response = result.ToResponse();

                    return Results.Ok(response);
                }
            )
            .WithName("GetOrders")
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders")
            .WithDescription("Get Orders");
    }

    public static Response ToResponse(this GetOrdersResult result)
    {
        return new Response(result.Orders);
    }
}
