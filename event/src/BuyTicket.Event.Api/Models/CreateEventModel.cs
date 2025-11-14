namespace BuyTicket.Event.Api.Models;

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
