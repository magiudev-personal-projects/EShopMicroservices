namespace Catalog.API.Features.DeleteProduct;

public record Request(Guid Id);

public record Command(Guid Id): ICommand<Result>;

public record Result(bool IsDeleted);

public record Response(bool IsDeleted);