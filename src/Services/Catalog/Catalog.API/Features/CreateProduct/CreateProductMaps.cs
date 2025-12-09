
namespace Catalog.API.Features.CreateProduct;

public static class CreateProductMaps
{
    public static CreateProductCommand FromRequestToCommand(CreateProductRequest request)
    {
        return new CreateProductCommand(request.Name, request.Categories, request.Description, request.ImageFile, request.Price);
    }

    public static Product FromCommandToEntity(CreateProductCommand command)
    {
        return new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
    }

    public static CreateProductResponse FromResultToResponse(CreateProductResult result)
    {
        return new CreateProductResponse(result.Id);
    }
}
