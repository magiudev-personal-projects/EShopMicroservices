using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Features.CreateOrder;

namespace Ordering.Infrastructure.Router.CreateOrder;

public record Request(OrderDto Order);

public record Response(Guid Id);

public static class Router
{
    public static void AddRoute(this IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/orders",
                async (Request request, ISender sender) =>
                {
                    var command = request.ToCommand();

                    var result = await sender.Send(command);

                    var response = result.ToResponse();

                    return Results.Created($"/orders/{response.Id}", response);
                }
            )
            .WithName("CreateOrder")
            .Produces<Response>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Order")
            .WithDescription("Create Order");
    }

    public static CreateOrderCommand ToCommand(this Request request)
    {
        return new CreateOrderCommand(request.Order);
    }

    public static Response ToResponse(this CreateOrderResult result)
    {
        return new Response(result.Id);
    }
}
