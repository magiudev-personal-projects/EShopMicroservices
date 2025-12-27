namespace Catalog.API.Features.CreateProduct;

internal class CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("CreateProductCommandHandler.Handle called with {@command}", command);
        var product = CreateProductMaps.FromCommandToEntity(command);
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        return new CreateProductResult(product.Id);
    }
}
