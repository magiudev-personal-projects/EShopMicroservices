
using BasketApi.Data;

namespace BasketApi.Features.StoreBasket;

public class Hanlder(IRepository repository): ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        var result = await repository.StoreBasket(command.Basket, cancellationToken);

        return new Result(result.UserName);
    }
}
