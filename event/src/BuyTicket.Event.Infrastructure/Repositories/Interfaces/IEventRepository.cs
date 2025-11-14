using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Infrastructure.Repositories.Interfaces;

public interface IEventRepository
{
    Task CreateEvent(IEvent @event, CancellationToken cancellationToken);
    Task<IEvent?> GetEvent(string id, CancellationToken cancellationToken);
}
