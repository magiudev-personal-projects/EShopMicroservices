
namespace Catalog.API.Features.GetProductsByCategory;

public class GetProductsByCategoryHandler(IDocumentSession session, ILogger<GetProductsByCategoryHandler> logger): IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsByCategoryHandler.Handle called with {@query}", query);
        var products = await session
            .Query<Product>()
            .Where(product => product.Categories.Contains(query.Category))
            .ToListAsync(cancellationToken);
        return new Result(products);
    }
}
