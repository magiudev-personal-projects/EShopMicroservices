using FluentValidation;

namespace BasketApi.Features.CheckoutBasket;

public class CheckoutBasketCommandValidator
    : AbstractValidator<Command>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.checkout)
            .NotNull().WithMessage("Checkout can't be nulll")
            .DependentRules(() =>
            {
                RuleFor(x => x.checkout.UserName)
                    .NotEmpty().WithMessage("UserName is required");
            });
    }
}