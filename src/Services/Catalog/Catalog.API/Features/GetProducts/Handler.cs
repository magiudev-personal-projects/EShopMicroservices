

namespace Catalog.API.Features.GetProducts;

public class Handler(IDocumentSession session) : IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new Result(products);
    }
}
