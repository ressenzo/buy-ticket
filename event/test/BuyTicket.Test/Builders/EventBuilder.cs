using BuyTicket.Domain.Entities;
using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Test.Builders;

internal sealed class EventBuilder : BaseBuilder<IEvent>
{
    public override IEvent Build() =>
        Event.Construct(
            name: "Name",
            description: "Description",
            startDate: DateTime.Now.AddDays(1),
            endDate: DateTime.Now.AddDays(2),
            address: "Address");
}
