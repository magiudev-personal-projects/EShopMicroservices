using BasketApi.Models;

namespace BasketApi.Features.StoreBasket;

public record Request(Basket Basket);

public record Response(string UserName);

public record Command(Basket Basket) : ICommand<Result>;

public record Result(string UserName);