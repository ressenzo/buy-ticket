using BuyTicket.Application.Commons;

namespace BuyTicket.Application.CreateEvent;

public interface ICreateEventUseCase
{
    public Task<Result<CreateEventResult>> CreateEvent(
        CreateEventRequest createEventRequest);
}