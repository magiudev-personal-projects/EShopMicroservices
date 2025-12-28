

namespace Catalog.API.Features.GetProducts;

public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {@query}", query);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new Result(products);
    }
}
