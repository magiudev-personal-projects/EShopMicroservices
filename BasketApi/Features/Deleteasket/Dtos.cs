namespace BasketApi.Features.DeleteBasket;

public record Response(bool IsSuccess);

public record Command(string UserName) : ICommand<Result>;

public record Result(bool IsSuccess);
