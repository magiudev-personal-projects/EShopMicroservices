using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);
