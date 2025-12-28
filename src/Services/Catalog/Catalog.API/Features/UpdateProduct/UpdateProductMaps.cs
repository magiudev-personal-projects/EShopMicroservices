namespace Catalog.API.Features.UpdateProduct;

public static class UpdateProductMaps
{
    public static UpdateProductCommand FromRequestToCommand(UpdateProductRequest request)
    {
        return new UpdateProductCommand(
            request.Id,
            request.Name, 
            request.Categories, 
            request.Description, 
            request.ImageFile, 
            request.Price
        );
    }

    public static void UpdateEntityFromCommand(UpdateProductCommand command, ref Product product)
    {
        product.Name = command.Name;
        product.Categories = command.Categories;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
    }

    public static UpdateProductResponse FromResultToResponse(UpdateProductResult result)
    {
        return new UpdateProductResponse(result.updated);
    }
}