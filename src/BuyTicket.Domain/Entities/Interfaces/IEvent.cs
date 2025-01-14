using BuyTicket.Domain.ValueObjects;

namespace BuyTicket.Domain.Entities.Interfaces;

public interface IEvent
{
    public string Name { get; }

    public string Description { get; }

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public AddressVO Address { get; }
}
