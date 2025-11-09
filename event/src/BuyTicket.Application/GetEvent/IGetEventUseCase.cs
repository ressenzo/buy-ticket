using BuyTicket.Application.Commons;

namespace BuyTicket.Application.GetEvent;

public interface IGetEventUseCase
{
    public Task<Result<GetEventResult>> GetEvent(
        string id,
        CancellationToken cancellationToken);
}
