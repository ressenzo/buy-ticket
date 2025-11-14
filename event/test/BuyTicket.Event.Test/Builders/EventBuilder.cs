using BuyTicket.Event.Domain.Entities.Interfaces;

namespace BuyTicket.Event.Test.Builders;

internal sealed class EventBuilder : BaseBuilder<IEvent>
{
    public override IEvent Build() =>
        Domain.Entities.Event.Construct(
            name: "Name",
            description: "Description",
            startDate: DateTime.Now.AddDays(1),
            endDate: DateTime.Now.AddDays(2),
            address: "Address");
}
