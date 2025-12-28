
namespace Catalog.API.Features.GetProductById;

public record Result(Product Product);

public record Response(Product Product);

public record Query(Guid Id) : IQuery<Result>;
