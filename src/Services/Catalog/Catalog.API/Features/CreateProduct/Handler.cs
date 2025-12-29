namespace Catalog.API.Features.CreateProduct;

internal class Handler(IDocumentSession session, ILogger<Handler> logger, CommandValidator commandValidator) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        var validationResult = await commandValidator.ValidateAsync(command);
        var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);
        if(errorMessages.Any())
            throw new ValidationException(errorMessages.FirstOrDefault());
        logger.LogInformation("Command: {command}", command);
        var product = Maps.FromCommandToEntity(command);
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        return new Result(product.Id);
    }
}
