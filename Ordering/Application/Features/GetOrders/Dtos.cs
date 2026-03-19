using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Ordering.Application.Dtos;

namespace Ordering.Application.Features.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest) 
    : IQuery<GetOrdersResult>;

public record GetOrdersResult(PaginatedResult<OrderDto> Orders);