
using BuyTicket.Application.Commons;
using BuyTicket.Application.Factories.Interfaces;
using BuyTicket.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuyTicket.Application.CreateEvent;

internal sealed class CreateEventUseCase(
    ILogger<CreateEventUseCase> logger,
    IEventFactory eventFactory,
    IEventRepository eventRepository) : ICreateEventUseCase
{
    public async Task<Result<CreateEventResult>> CreateEvent(CreateEventRequest createEventRequest)
    {
        logger.LogInformation("Begin process {Process}", nameof(CreateEvent));
        var @event = eventFactory.Construct(createEventRequest);
        if (!@event.IsValid())
        {
            logger.LogError("Errors: {Errors}", @event.Errors);
            return Result<CreateEventResult>.ValidationError(
                @event.Errors);
        }

        logger.LogInformation("Event was succesfully created: {Event}",
            @event);
        await eventRepository.CreateEvent(@event);
        var result = CreateEventResult.FromEntity(@event);
        return Result<CreateEventResult>.Success(result);
    }
}
