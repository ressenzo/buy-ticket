using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Infrastructure.Repositories.Interfaces;

public interface IEventRepository
{
    Task CreateEvent(IEvent @event, CancellationToken cancellationToken);
    Task<IEvent> GetEvent(string id, CancellationToken cancellationToken);
}
