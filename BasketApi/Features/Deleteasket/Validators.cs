using FluentValidation;

namespace BasketApi.Features.DeleteBasket;

public class DeleteBasketCommandValidator : AbstractValidator<Command>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
