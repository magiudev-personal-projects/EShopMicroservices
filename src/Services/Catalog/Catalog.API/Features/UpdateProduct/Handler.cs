
using Catalog.API.Exceptions;

namespace Catalog.API.Features.UpdateProduct;

public class Handler(IDocumentSession session, ILogger<Handler> logger) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductHanlder.Handle called with {@command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if(product == null)
            throw new ProductNotFoundException(command.Id);

        Maps.UpdateEntityFromCommand(command, ref product);
        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);
        return new Result(true);
    }
}