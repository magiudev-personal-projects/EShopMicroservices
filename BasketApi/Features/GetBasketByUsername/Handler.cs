using BasketApi.Data;

namespace BasketApi.Features.GetBasketByUsername;

public class Handler(IRepository repository): IQueryHandler<Query, Result>
{
    public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(query.UserName);

        return new Result(basket);
    }
}

