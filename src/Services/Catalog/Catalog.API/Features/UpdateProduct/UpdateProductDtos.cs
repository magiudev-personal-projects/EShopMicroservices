namespace Catalog.API.Features.UpdateProduct;

public record Request(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
);

public record Command(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
): ICommand<Result>;

public record Result(bool updated);
public record Response(bool updated);
