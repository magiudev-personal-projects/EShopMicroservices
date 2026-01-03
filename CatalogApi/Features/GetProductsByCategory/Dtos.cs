namespace CatalogApi.Features.GetProductsByCategory;

public record Result(IEnumerable<Product> products);

public record Response(IEnumerable<Product> products);

public record Query(string Category) : IQuery<Result>;
