using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Application.GetEvent;

public sealed class GetEventResult(
    string id,
    string name,
    string description,
    DateTime startDate,
    DateTime endDate,
    string address)
{
    public string Id { get; } = id;

    public string Name { get; } = name;

    public string Description { get; } = description;

    public DateTime StartDate { get; } = startDate;

    public DateTime EndDate { get; } = endDate;

    public string Address { get; } = address;

    public static GetEventResult FromEntity(IEvent @event) =>
        new(
            @event.Id,
            @event.Name,
            @event.Description,
            @event.StartDate,
            @event.EndDate,
            @event.Address);
}
