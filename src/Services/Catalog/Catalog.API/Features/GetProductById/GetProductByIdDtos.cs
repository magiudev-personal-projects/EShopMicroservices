
namespace Catalog.API.Features.GetProductById;

public record GetProductByIdResult(Product Product);

public record GetProductByIdResponse(Product Product);

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
