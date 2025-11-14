using BuyTicket.Event.Domain.Entities;
using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Infrastructure.Models;

public class EventModel
{
    public string Id { get; } = null!;

    public string Name { get; } = null!;

    public string Description { get; } = null!;

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public string Address { get; } = null!;

    public IEvent ToEntity() =>
        Domain.Entities.Event.Construct(
            Id,
            Name,
            Description,
            StartDate,
            EndDate,
            Address);
}
