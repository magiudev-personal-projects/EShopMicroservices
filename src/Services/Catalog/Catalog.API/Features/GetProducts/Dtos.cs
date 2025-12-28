
namespace Catalog.API.Features.GetProducts;

public record Result(IReadOnlyList<Product> Products);

public record Response(IEnumerable<Product> Products);

public record Query: IQuery<Result>;
