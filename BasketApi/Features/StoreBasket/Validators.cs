using FluentValidation;

namespace BasketApi.Features.StoreBasket;

public class CommandValidator: AbstractValidator<Command>
{
    public CommandValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull().WithMessage("Cart can not be null")
            .DependentRules(() =>
            {
                RuleFor(x => x.Cart.UserName)
                    .NotEmpty().WithMessage("UserName is required");
            });
    }
}