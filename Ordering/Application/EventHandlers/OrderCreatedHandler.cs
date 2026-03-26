using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Maps;
using Ordering.Domain.Events;

namespace Ordering.Application.EventHandlers;

public class OrderCreatedEventHandler(
    IPublishEndpoint publishEndpoint,
    ILogger<OrderCreatedEventHandler> logger
)
    :
    // This is a domain event handler
    INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        var orderCreatedIntegrationEvent = domainEvent.order.ToDto();
        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}
