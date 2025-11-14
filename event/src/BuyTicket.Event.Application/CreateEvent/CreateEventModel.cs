using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Application.CreateEvent;

public sealed class CreateEventRequest(
    string name,
    string description,
    DateTime startDate,
    DateTime endDate,
    string address)
{
    public string Name { get; } = name;

    public string Description { get; } = description;

    public DateTime StartDate { get; } = startDate;

    public DateTime EndDate { get; } = endDate;

    public string Address { get; } = address;
}

public sealed class CreateEventResult(
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

    public static CreateEventResult FromEntity(IEvent @event) =>
        new(
            @event.Id,
            @event.Name,
            @event.Description,
            @event.StartDate,
            @event.EndDate,
            @event.Address);
}
