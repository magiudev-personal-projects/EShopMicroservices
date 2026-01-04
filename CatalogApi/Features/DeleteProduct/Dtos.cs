namespace CatalogApi.Features.DeleteProduct;

public record Command(Guid Id): ICommand<Result>;

public record Result(bool IsDeleted);

public record Response(bool IsDeleted);