using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Features.GetOrderByUsername;

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;

public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
