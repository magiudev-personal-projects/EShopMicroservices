using BasketApi.Models;

namespace BasketApi.Features.StoreBasket;

public record Request(ShoppingCart Cart);

public record Response(string UserName);

public record Command(ShoppingCart Cart) : ICommand<Result>;

public record Result(string UserName);