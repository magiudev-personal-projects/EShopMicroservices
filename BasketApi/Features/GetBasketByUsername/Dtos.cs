using BasketApi.Models;

namespace BasketApi.Features.GetBasketByUsername;

public record Result(ShoppingCart ShoppingCart);

public record Response(ShoppingCart ShoppingCart);

public record Query(string UserName): IQuery<Result>;
