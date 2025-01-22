using BuyTicket.Domain.Commons;
using BuyTicket.Domain.Entities;
using BuyTicket.Domain.ValueObjects;
using BuyTicket.Test.Builders;
using BuyTicket.Test.Commons;

namespace BuyTicket.Test.Entities;

public class EventTest
{
    private readonly string _name;
    private readonly string _description;
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly Address _address;

    public EventTest()
    {
        _name = "Event";
        _description = "Description";
        _startDate = DateTime.Now.AddDays(1);
        _endDate = DateTime.Now.AddDays(2);
        _address = new AddressBuilder()
            .Build();
    }

    [Fact]
    public void ShouldSetValues()
    {
        // Arrange - Act
        var @event = Event.Construct(_name,
            _description,
            _startDate,
            _endDate,
            _address);

        // Assert
        @event.Name.ShouldBe(_name);
        @event.Description.ShouldBe(_description);
        @event.StartDate.ShouldBe(_startDate);
        @event.EndDate.ShouldBe(_endDate);
        @event.Address.ShouldBe(_address);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void WhenNameIsInvalid_ShouldReturnIsValidFalse(string name)
    {
        // Arrange
        var @event = Event.Construct(name,
            _description,
            _startDate,
            _endDate,
            _address);

        // Act
        var isValid = @event.IsValid();

        // Assert
        isValid.ShouldBeFalse();
        @event.Errors.ShouldHaveSingleItem();
        @event.Errors.First().ShouldBe(Error.InvalidProperty(nameof(Event.Name)));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void WhenDescriptionIsInvalid_ShouldReturnIsValidFalse(string description)
    {
        // Arrange
        var @event = Event.Construct(_name,
            description,
            _startDate,
            _endDate,
            _address);

        // Act
        var isValid = @event.IsValid();

        // Assert
        isValid.ShouldBeFalse();
        @event.Errors.ShouldHaveSingleItem();
        @event.Errors.First().ShouldBe(Error.InvalidProperty(nameof(Event.Description)));
    }

    [Fact]
    public void WhenStartDateIsLessThanNow_ShouldReturnIsValidFalse()
    {
        // Arrange
        var startDate = DateTime.Now.AddMinutes(-1);
        var @event = Event.Construct(_name,
            _description,
            startDate,
            _endDate,
            _address);

        // Act
        var isValid = @event.IsValid();

        // Assert
        isValid.ShouldBeFalse();
        @event.Errors.ShouldHaveSingleItem();
        @event.Errors.First().ShouldBe(Error.DateBeforeNow(nameof(Event.StartDate)));
    }

    [Fact]
    public void WhenStartDateIsLessThanEndDate_ShouldReturnIsValidFalse()
    {
        // Arrange
        var startDate = DateTime.Now.AddDays(1);
        var endDate = startDate.AddSeconds(-1);
        var @event = Event.Construct(_name,
            _description,
            startDate,
            endDate,
            _address);

        // Act
        var isValid = @event.IsValid();

        // Assert
        isValid.ShouldBeFalse();
        @event.Errors.ShouldHaveSingleItem();
        @event.Errors.First().ShouldBe(Error.DateBefore);
    }

    [Fact]
    public void WhenAddressIsNull_ShouldReturnIsValidFalse()
    {
        // Arrange
        var @event = Event.Construct(_name,
            _description,
            _startDate,
            _endDate,
            address: null!);

        // Act
        var isValid = @event.IsValid();

        // Assert
        isValid.ShouldBeFalse();
        @event.Errors.ShouldHaveSingleItem();
        @event.Errors.First().ShouldBe(Error.NullProperty(nameof(Event.Address)));
    }
}
