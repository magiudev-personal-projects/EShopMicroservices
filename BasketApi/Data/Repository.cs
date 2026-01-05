using BasketApi.Models;
using Marten;

namespace BasketApi.Data;

public class Repository(IDocumentSession session): IRepository
{
    public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);
        
        return basket is null ? throw new BasketNotFoundException(userName) : basket;
    }

    public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
