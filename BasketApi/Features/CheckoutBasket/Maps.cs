namespace BasketApi.Features.CheckoutBasket;

public static class Maps
{
    public static Command FromRequestToCommand(Request request)
    {
        return new Command(request.checkout);
    }

    public static Response FromResultToResponse(Result resutl)
    {
        return new Response(resutl.IsSuccess);
    }
}
