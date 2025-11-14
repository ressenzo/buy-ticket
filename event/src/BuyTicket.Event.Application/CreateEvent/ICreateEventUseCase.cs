using BuyTicket.Event.Application.Commons;

namespace BuyTicket.Event.Application.CreateEvent;

public interface ICreateEventUseCase
{
    public Task<Result<CreateEventResult>> CreateEvent(
        CreateEventRequest createEventRequest,
        CancellationToken cancellationToken);
}