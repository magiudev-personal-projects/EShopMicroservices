using BuildingBlocks.CQRS;

namespace Catalog.API.Features.CreateProduct;

public record CreateProductCommand(
    string name,
    List<string> categories,
    string descriton,
    string imageFile,
    decimal price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
