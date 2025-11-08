using BuyTicket.Application.CreateEvent;

namespace BuyTicket.Test.Builders;

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