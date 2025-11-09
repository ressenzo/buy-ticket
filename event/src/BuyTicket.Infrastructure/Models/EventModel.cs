using BuyTicket.Domain.Entities;
using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Infrastructure.Models;

public class EventModel
{
    public string Id { get; } = null!;

    public string Name { get; } = null!;

    public string Description { get; } = null!;

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public string Address { get; } = null!;

    public IEvent ToEntity() =>
        Event.Construct(
            Id,
            Name,
            Description,
            StartDate,
            EndDate,
            Address);
}
