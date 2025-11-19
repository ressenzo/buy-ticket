
using BuyTicket.Event.Application.Commons;
using BuyTicket.Event.Application.Factories.Interfaces;
using BuyTicket.Event.Application.Repositories;
using Microsoft.Extensions.Logging;

namespace BuyTicket.Event.Application.CreateEvent;

internal sealed class CreateEventUseCase(
    ILogger<CreateEventUseCase> logger,
    IEventFactory eventFactory,
    IEventRepository eventRepository) : ICreateEventUseCase
{
    public async Task<Result<CreateEventResult>> CreateEvent(
        CreateEventRequest createEventRequest,
        CancellationToken cancellationToken)
    {
        try
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
            await eventRepository.CreateEvent(@event, cancellationToken);
            var result = CreateEventResult.FromEntity(@event);
            return Result<CreateEventResult>.Success(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{Message}", ex.Message);
            return Result<CreateEventResult>.InternalError();
        }
    }
}
