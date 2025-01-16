using BuyTicket.Domain.ValueObjects;

namespace BuyTicket.Domain.Entities.Interfaces;

public interface IEvent : IEntity
{
    public string Name { get; }

    public string Description { get; }

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public Address Address { get; }
}
