using BuyTicket.Domain.Entities;

namespace BuyTicket.Domain.Commons;

public class Error
{
    public string Code { get; } = null!;
    
    public string Message { get; } = null!;

    private Error(string code,
        string message)
    {
        Code = code;
        Message = message;
    }

    public static Error Create(string code, string message) =>
        new(code, message);

    public static Error InvalidProperty(string propertyName) =>
        new(nameof(InvalidProperty), $"{propertyName} is invalid");

    public static Error DateBeforeNow(string propertyName) =>
        new(nameof(DateBeforeNow), $"{propertyName} is a date before now");

    public static Error DateBefore =>
        new(nameof(DateBefore), $"{nameof(Event.StartDate)} should be less than {nameof(Event.EndDate)}");

    public static Error NullProperty(string propertyName) =>
        new(nameof(NullProperty), $"{propertyName} can not be null");
}
