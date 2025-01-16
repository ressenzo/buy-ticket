namespace BuyTicket.Domain.ValueObjects;

public record Address(
    string Street,
    string Number,
    string City,
    string State,
    string Country)
{
    public string Street { get; private set; } = Street;

    public string Number { get; private set; } = Number;

    public string? Complement { get; private set; }

    public string City { get; private set; } = City;

    public string State { get; private set; } = State;

    public string Country { get; private set; } = Country;

    public void SetComplement(string complement) =>
        Complement = complement;
}