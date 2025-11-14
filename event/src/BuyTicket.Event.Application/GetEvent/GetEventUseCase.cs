using BuyTicket.Event.Application.Commons;
using BuyTicket.Event.Domain.Commons;
using BuyTicket.Event.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuyTicket.Event.Application.GetEvent;

internal sealed class GetEventUseCase(
    ILogger<GetEventUseCase> logger,
    IEventRepository eventRepository) : IGetEventUseCase
{
    public async Task<Result<GetEventResult>> GetEvent(
        string id,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Begin process {Process}", nameof(GetEvent));
            if (string.IsNullOrWhiteSpace(id))
            {
                var error = Error.InvalidProperty(nameof(id));
                return Result<GetEventResult>.ValidationError([error]);
            }

            var @event = await eventRepository.GetEvent(id, cancellationToken);
            if (@event is null)
            {
                return Result<GetEventResult>.NotFound(
                    message: $"Event {id} was not found");
            }

            var result = GetEventResult.FromEntity(@event);
            return Result<GetEventResult>.Success(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{Message}", ex.Message);
            return Result<GetEventResult>.InternalError();
        }
    }
}
