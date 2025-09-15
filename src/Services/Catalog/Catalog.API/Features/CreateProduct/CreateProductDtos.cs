using BuildingBlocks.CQRS;

namespace Catalog.API.Features.CreateProduct;

public record CreateProductRequest(
     string Name,
     List<string> Categories,
     string Description,
     string ImageFile,
     decimal Price
);

public record CreateProductResponse(Guid Id);

public record CreateProductCommand(
    string name,
    List<string> categories,
    string descriton,
    string imageFile,
    decimal price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);