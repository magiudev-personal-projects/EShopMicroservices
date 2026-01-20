namespace CatalogApi.Features.CreateProduct;

public class CommandValidator : AbstractValidator<Command>
{
    public CommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(command => command.Categories).NotEmpty().WithMessage("Categories is required");
        RuleFor(command => command.ImageFile).NotEmpty().WithMessage("Image file is required");
        RuleFor(command => command.Price).GreaterThan(0).WithMessage("Price must be greater than");
    }
}