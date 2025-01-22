using BuyTicket.Domain.ValueObjects;

namespace BuyTicket.Test.Builders;

public class AddressBuilder : BaseBuilder<Address>
{
    public override Address Build() =>
        new(Street: "Street",
            Number: "Number",
            City: "City",
            State: "State",
            Country: "Country");
}
