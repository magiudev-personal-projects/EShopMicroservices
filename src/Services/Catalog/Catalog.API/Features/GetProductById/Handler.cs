

using Catalog.API.Exceptions;

namespace Catalog.API.Features.GetProductById;

public class Handler(IDocumentSession session) : IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product == null)
            throw new ProductNotFoundException(query.Id);

        return new Result(product);
    }
}
