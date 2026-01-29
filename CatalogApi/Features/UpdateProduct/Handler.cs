using CatalogApi.Exceptions;

namespace CatalogApi.Features.UpdateProduct;

public class Handler(IDocumentSession session) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product == null)
            throw new ProductNotFoundException(command.Id);

        Maps.UpdateEntityFromCommand(command, ref product);
        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);
        return new Result(true);
    }
}
