using BuyTicket.Application.CreateEvent;
using BuyTicket.Application.Factories.Interfaces;
using BuyTicket.Domain.Entities;
using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Application.Factories;

internal sealed class EventFactory : IEventFactory
{
    public IEvent Construct(CreateEventRequest createEventRequest) =>
        Event.Construct(
            createEventRequest.Name,
            createEventRequest.Description,
            createEventRequest.StartDate,
            createEventRequest.EndDate,
            createEventRequest.Address);
}
