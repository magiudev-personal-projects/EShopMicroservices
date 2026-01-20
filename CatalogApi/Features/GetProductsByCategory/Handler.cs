
namespace CatalogApi.Features.GetProductsByCategory;

public class Handler(IDocumentSession session) : IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        var products = await session
            .Query<Product>()
            .Where(product => product.Categories.Contains(query.Category))
            .ToListAsync(cancellationToken);
        return new Result(products);
    }
}
