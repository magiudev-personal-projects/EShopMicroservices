namespace BasketApi.Features.DeleteBasket;

public static class Maps
{
    public static Response FromResultToResult(Result result)
    {
        return new Response(result.IsSuccess);
    }
}