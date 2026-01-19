using System.Text.Json;
using BasketApi.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketApi.Data;

public class CachedRepository(IRepository _repository, IDistributedCache _cache) : IRepository
{
    public async Task<Basket> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var rawCacheEntry = await _cache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(rawCacheEntry))
        {
            var cacheEntry = JsonSerializer.Deserialize<Basket>(rawCacheEntry ?? "");
            return cacheEntry!;
        }

        var basket = await _repository.GetBasket(userName, cancellationToken);
        
        var serializedBasket = JsonSerializer.Serialize(basket);
        await _cache.SetStringAsync(userName, serializedBasket, cancellationToken);

        return basket;
    }

    public async Task<Basket> StoreBasket(Basket basket, CancellationToken cancellationToken = default)
    {
        var result = await _repository.StoreBasket(basket, cancellationToken);
        var serializedResult = JsonSerializer.Serialize(result);
        await _cache.SetStringAsync(basket.UserName, serializedResult, cancellationToken);
        return result;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteBasket(userName, cancellationToken);
        await _cache.RemoveAsync(userName, cancellationToken);
        return true;
    }
}