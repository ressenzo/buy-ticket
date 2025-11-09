using BuyTicket.Application.Commons;
using BuyTicket.Domain.Commons;
using BuyTicket.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuyTicket.Application.GetEvent;

internal sealed class GetEventUseCase(
    ILogger<GetEventUseCase> logger,
    IEventRepository eventRepository) : IGetEventUseCase
{
    public async Task<Result<GetEventResult>> GetEvent(string id)
    {
        logger.LogInformation("Begin process {Process}", nameof(GetEvent));
        if (string.IsNullOrWhiteSpace(id))
        {
            var error = Error.InvalidProperty(nameof(id));
            return Result<GetEventResult>.ValidationError([error]);
        }

        var @event = await eventRepository.GetEvent(id);
        if (@event is null)
        {
            return Result<GetEventResult>.NotFound(
                message: $"Event {id} was not found");
        }

        var result = GetEventResult.FromEntity(@event);
        return Result<GetEventResult>.Success(result);
    }
}
