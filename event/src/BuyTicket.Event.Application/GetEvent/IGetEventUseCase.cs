using BuyTicket.Event.Application.Commons;

namespace BuyTicket.Event.Application.GetEvent;

public interface IGetEventUseCase
{
    public Task<Result<GetEventResult>> GetEvent(
        string id,
        CancellationToken cancellationToken);
}
