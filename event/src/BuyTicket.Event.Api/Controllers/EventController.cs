using System.Net;
using BuyTicket.Event.Application.Commons;
using BuyTicket.Event.Application.CreateEvent;
using BuyTicket.Event.Application.GetEvent;
using Microsoft.AspNetCore.Mvc;

namespace BuyTicket.Event.Api.Controllers;

[ApiController]
[Route("api/events")]
public sealed class EventController(
    ICreateEventUseCase createEventUseCase,
    IGetEventUseCase getEventUseCase) : ControllerBase
{
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetEvent(
        [FromRoute] string id,
        CancellationToken cancellationToken)
    {
        var result = await getEventUseCase.GetEvent(
            id,
            cancellationToken);
        return result.ResultType switch
        {
            ResultType.NOT_FOUND => NotFound(result.Errors),
            ResultType.SUCCESS => Ok(result.Content),
            _ => StatusCode((int)HttpStatusCode.InternalServerError, "An error has happened")
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent(
        [FromBody] Models.CreateEventRequest request,
        CancellationToken cancellationToken)
    {
        var useCaseRequest = new CreateEventRequest(
            request.Name,
            request.Description,
            request.StartDate,
            request.EndDate,
            request.Address);
        var result = await createEventUseCase.CreateEvent(
            useCaseRequest,
            cancellationToken);
        return result.ResultType switch
        {
            ResultType.VALIDATION_ERROR => BadRequest(result.Errors),
            ResultType.SUCCESS => Created($"/api/events/id/{result!.Content!.Id}", result.Content),
            _ => StatusCode((int)HttpStatusCode.InternalServerError, "An error has happened")
        };
    }
}
