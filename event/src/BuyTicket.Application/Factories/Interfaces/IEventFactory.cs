using BuyTicket.Application.CreateEvent;
using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Application.Factories.Interfaces;

public interface IEventFactory
{
    IEvent Construct(CreateEventRequest createEventRequest);
}
