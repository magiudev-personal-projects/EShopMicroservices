namespace Catalog.API.Features.CreateProduct;

internal class Handler(IDocumentSession session, ILogger<Handler> logger) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        logger.LogInformation("CreateProductCommandHandler.Handle called with {@command}", command);
        var product = Maps.FromCommandToEntity(command);
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        return new Result(product.Id);
    }
}
