
using BuildingBlocks.Exceptions;
using Marten.Pagination;

namespace CatalogApi.Features.GetProducts;

public class Handler(IDocumentSession session) : IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        var pageNumber = query.pageNumber ?? 1;
        var pageSize = Math.Min(query.pageSize ?? 10, 200);
        var products = await session
            .Query<Product>()
            .ToPagedListAsync(pageNumber, pageSize, cancellationToken);

        if(products is IPagedList<Product> nonNullableProducts)
            return new Result(nonNullableProducts);

        throw new InternalServerException("Something went wrong");
    }
}
