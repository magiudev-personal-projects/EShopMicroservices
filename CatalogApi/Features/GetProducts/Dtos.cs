
using Marten.Pagination;

namespace CatalogApi.Features.GetProducts;

public record Request(int? pageNumber, int? pageSize);

public record Result(IPagedList<Product> Products);

public record Response(IEnumerable<Product> Products);

public record Query(int? pageNumber, int? pageSize) : IQuery<Result>;
