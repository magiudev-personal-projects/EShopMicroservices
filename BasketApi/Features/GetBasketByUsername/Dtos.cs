using BasketApi.Models;

namespace BasketApi.Features.GetBasketByUsername;

public record Result(Basket basket);

public record Response(Basket basket);

public record Query(string UserName) : IQuery<Result>;
