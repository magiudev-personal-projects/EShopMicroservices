
namespace CatalogApi.Features.CreateProduct;

public static class Maps
{
    public static Command FromRequestToCommand(Request request)
    {
        return new Command(request.Name, request.Categories, request.Description, request.ImageFile, request.Price);
    }

    public static Product FromCommandToEntity(Command command)
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

    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.Id);
    }
}
