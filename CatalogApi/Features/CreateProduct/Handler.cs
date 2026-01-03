namespace CatalogApi.Features.CreateProduct;

internal class Handler(IDocumentSession session) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        var product = Maps.FromCommandToEntity(command);
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        return new Result(product.Id);
    }
}
