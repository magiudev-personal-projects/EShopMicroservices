namespace Catalog.API.Features.GetProductsByCategory;

public record GetProductsByCategoryResult(IEnumerable<Product> products);

public record GetProductsByCategoryResponse(IEnumerable<Product> products);

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
