using FluentValidation;

namespace BasketApi.Features.StoreBasket;

public class CommandValidator : AbstractValidator<Command>
{
    public CommandValidator()
    {
        RuleFor(x => x.Basket)
            .NotNull().WithMessage("Basket can not be null")
            .DependentRules(() =>
            {
                RuleFor(x => x.Basket.UserName)
                    .NotEmpty().WithMessage("UserName is required");
            });
    }
}