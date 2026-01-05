using BuildingBlocks.Exceptions;

namespace BasketApi;

public class BasketNotFoundException : NotFoundException
{
    public BasketNotFoundException(string userName) : base("Basket", userName)
    {}
}
