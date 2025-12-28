
using Catalog.API.Exceptions;

namespace Catalog.API.Features.DeleteProduct;

public class Handler(IDocumentSession session, ILogger<Handler> logger): ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Command: {command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if(product == null)
            throw new ProductNotFoundException(command.Id);
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);
        var result = new Result(true);
        return result;
    }
}
