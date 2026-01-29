namespace BasketApi.Features.GetBasketByUsername;

public class Maps
{
    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.basket);
    }
}
