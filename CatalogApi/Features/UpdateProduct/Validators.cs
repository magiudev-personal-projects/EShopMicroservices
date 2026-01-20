namespace CatalogApi.Features.UpdateProduct;

public class CommandValidators : AbstractValidator<Command>
{
    public CommandValidators()
    {
        RuleFor(command => command.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 150).WithMessage("Name must be betwen 1 and 150 chars");
        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
