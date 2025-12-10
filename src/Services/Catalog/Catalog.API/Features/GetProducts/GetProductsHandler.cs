

namespace Catalog.API.Features.GetProducts;

public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {@query}", query);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        if (!products.Any())
        {
            return null;
        }

        return new GetProductsResult(products);
    }
}
