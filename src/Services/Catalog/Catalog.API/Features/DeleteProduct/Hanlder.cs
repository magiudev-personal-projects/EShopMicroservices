
// using Catalog.API.Exceptions;

namespace Catalog.API.Features.DeleteProduct;

public class Hanlder(IDocumentSession session): ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        // var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        // if(product == null)
        //     throw new ProductNotFoundException(command.Id);
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);
        var result = new Result(true);
        return result;
    }
}
