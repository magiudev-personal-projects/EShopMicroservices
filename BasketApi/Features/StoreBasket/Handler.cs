using BasketApi.Data;
using BasketApi.Models;
using DiscountGrpc;

namespace BasketApi.Features.StoreBasket;

public class Hanlder(
    IRepository repository,
    DiscountProtoService.DiscountProtoServiceClient discountProto
) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        await DeductDiscount(command.Basket, cancellationToken);
        var result = await repository.StoreBasket(command.Basket, cancellationToken);
        return new Result(result.UserName);
    }

    private async Task DeductDiscount(Basket basket, CancellationToken cancellationToken)
    {
        foreach (var item in basket.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(
                new GetDiscountRequest { ProductName = item.ProductName },
                cancellationToken: cancellationToken
            );
            item.Price -= coupon.Amount;
        }
    }
}
