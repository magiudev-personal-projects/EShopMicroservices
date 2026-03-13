namespace Ordering.Domain.Abstractions;

public abstract class Aggregate<T> : Entity<T>, IAggregate<T>
{
    public List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvents)
    {
        _domainEvents.Add(domainEvents);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        throw new NotImplementedException();
    }
}
