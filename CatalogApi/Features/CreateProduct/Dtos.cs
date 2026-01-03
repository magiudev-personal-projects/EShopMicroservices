namespace CatalogApi.Features.CreateProduct;

public record Request(
     string Name,
     List<string> Categories,
     string Description,
     string ImageFile,
     decimal Price
);

public record Response(Guid Id);

public record Command(
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<Result>;

public record Result(Guid Id);