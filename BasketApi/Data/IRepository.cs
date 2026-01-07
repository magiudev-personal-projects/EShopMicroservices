using BasketApi.Models;

namespace BasketApi.Data;

public interface IRepository
{
    Task<Basket> GetBasket(string userName, CancellationToken cancellationToken = default);
    Task<Basket> StoreBasket(Basket basket, CancellationToken cancellationToken = default);
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
}
