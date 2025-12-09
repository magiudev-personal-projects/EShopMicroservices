

namespace Catalog.API.Features.GetProducts;

public class GetProductsCommandHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        if (!products.Any())
        {
            return null;
        }

        return new GetProductsResult(products);
    }
}
