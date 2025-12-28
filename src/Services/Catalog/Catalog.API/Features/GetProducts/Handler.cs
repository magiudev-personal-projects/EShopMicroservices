

namespace Catalog.API.Features.GetProducts;

public class Handler(IDocumentSession session, ILogger<Handler> logger) : IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Query: {query}", query);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new Result(products);
    }
}
