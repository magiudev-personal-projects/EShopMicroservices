
namespace Catalog.API.Features.GetProducts;

public record GetProductsResult(IReadOnlyList<Product> Products);

public record GetProductsResponse(IEnumerable<Product> Products);

public record GetProductsQuery : IQuery<GetProductsResult>;
