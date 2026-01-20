namespace BasketApi.Features.CheckoutBasket;

using BasketApi.Data;

public class CheckoutBasketCommandHandler
    (IRepository repository
    // , IPublishEndpoint publishEndpoint
    ) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        // get existing basket with total price
        // Set totalprice on basketcheckout event message
        // send basket checkout event to rabbitmq using masstransit
        // delete the basket

        var basket = await repository.GetBasket(command.checkout.UserName, cancellationToken);
        if (basket == null)
            return new Result(false);

        // var eventMessage = command.checkout.Adapt<BasketCheckoutEvent>();
        // eventMessage.TotalPrice = basket.TotalPrice;

        // await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasket(command.checkout.UserName, cancellationToken);

        return new Result(true);
    }
}