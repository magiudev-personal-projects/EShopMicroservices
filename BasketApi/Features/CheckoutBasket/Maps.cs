using BuildingBlocks.Messaging.Events;

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

    public static BasketCheckoutEvent FromCommandToEvent(Command command)
    {
        return new BasketCheckoutEvent
        {
            UserName = command.checkout.UserName,
            CustomerId = command.checkout.CustomerId,
            TotalPrice = command.checkout.TotalPrice,
            FirstName = command.checkout.FirstName,
            LastName = command.checkout.LastName,
            EmailAddress = command.checkout.EmailAddress,
            AddressLine = command.checkout.AddressLine,
            Country = command.checkout.Country,
            State = command.checkout.State,
            ZipCode = command.checkout.ZipCode,
            CardName = command.checkout.CardName,
            CardNumber = command.checkout.CardNumber,
            Expiration = command.checkout.Expiration,
            CVV = command.checkout.CVV,
            PaymentMethod = command.checkout.PaymentMethod,
        };
    }
}
