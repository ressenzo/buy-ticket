using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Application.Repositories;

public interface IEventRepository
{
    Task CreateEvent(IEvent @event, CancellationToken cancellationToken);
    Task<IEvent?> GetEvent(string id, CancellationToken cancellationToken);
}
