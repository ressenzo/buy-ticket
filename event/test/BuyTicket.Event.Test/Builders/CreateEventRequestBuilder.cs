using BuyTicket.Event.Application.CreateEvent;

namespace BuyTicket.Event.Test.Builders;

internal class CreateEventRequestBuilder : BaseBuilder<CreateEventRequest>
{
    public override CreateEventRequest Build() =>
        new(
            name: "Event",
            description: "Description",
            startDate: DateTime.Now.AddDays(1),
            endDate: DateTime.Now.AddDays(2),
            address: "Address");
}