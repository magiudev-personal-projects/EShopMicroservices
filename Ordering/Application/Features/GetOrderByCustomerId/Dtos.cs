using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Features.GetOrdersByCustomerId;

public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerResult>;

public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
