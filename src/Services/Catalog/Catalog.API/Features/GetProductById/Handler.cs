

using Catalog.API.Exceptions;

namespace Catalog.API.Features.GetProductById;

public class Handler(IDocumentSession session, ILogger<Handler> logger) : IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Query: {query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product == null)
            throw new ProductNotFoundException(query.Id);

        return new Result(product);
    }
}
