namespace BasketApi.Features.StoreBasket;

public class Maps
{
    public static Command FromRequestToCommand(Request request)
    {
        return new Command(request.Cart);
    }

    public static Response FromResultToResponse(Result result)
    {
        return new Response(result.UserName);
    }
}
