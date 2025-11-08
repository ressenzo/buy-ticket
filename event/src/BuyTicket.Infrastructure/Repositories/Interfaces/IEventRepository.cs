using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Infrastructure.Repositories.Interfaces;

public interface IEventRepository
{
    Task CreateEvent(IEvent @event);
}
