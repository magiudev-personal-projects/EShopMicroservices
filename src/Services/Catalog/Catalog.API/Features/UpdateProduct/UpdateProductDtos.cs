namespace Catalog.API.Features.UpdateProduct;

public record UpdateProductRequest(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
);

public record UpdateProductCommand(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
): ICommand<UpdateProductResult>;

public record UpdateProductResult(bool updated);
public record UpdateProductResponse(bool updated);
