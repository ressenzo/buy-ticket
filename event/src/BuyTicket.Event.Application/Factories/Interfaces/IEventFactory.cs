using BuyTicket.Event.Application.CreateEvent;
using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Application.Factories.Interfaces;

public interface IEventFactory
{
    IEvent Construct(CreateEventRequest createEventRequest);
}
