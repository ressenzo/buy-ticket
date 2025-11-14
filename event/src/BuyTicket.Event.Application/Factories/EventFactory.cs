using BuyTicket.Event.Application.CreateEvent;
using BuyTicket.Event.Application.Factories.Interfaces;
using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Application.Factories;

internal sealed class EventFactory : IEventFactory
{
    public IEvent Construct(CreateEventRequest createEventRequest) =>
        Domain.Entities.Event.Construct(
            createEventRequest.Name,
            createEventRequest.Description,
            createEventRequest.StartDate,
            createEventRequest.EndDate,
            createEventRequest.Address);
}
