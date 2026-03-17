using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Features.CreateOrder;

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);
