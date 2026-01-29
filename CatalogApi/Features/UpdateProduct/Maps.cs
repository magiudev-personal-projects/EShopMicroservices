namespace CatalogApi.Features.UpdateProduct;

public static class Maps
{
    public static Command FromRequestToCommand(Guid Id, Request request)
    {
        return new Command(
            Id,
            request.Name,
            request.Categories,
            request.Description,
            request.ImageFile,
            request.Price
        );
    }

    public static void UpdateEntityFromCommand(Command command, ref Product product)
    {
        product.Name = command.Name;
        product.Categories = command.Categories;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
    }

    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.updated);
    }
}
