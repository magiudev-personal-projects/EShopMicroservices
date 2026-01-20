using BasketApi.Data;

namespace BasketApi.Features.DeleteBasket;

public class DeleteBasketCommandHandler(IRepository repository)
    : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(command.UserName, cancellationToken);

        return new Result(true);
    }
}
