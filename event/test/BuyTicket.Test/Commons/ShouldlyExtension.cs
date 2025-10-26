using BuyTicket.Domain.Commons;

namespace BuyTicket.Test.Commons;

public static class ShouldlyExtension
{
    public static void ShouldBe(this Error error,
        Error comparisonError)
    {
        if (error.Code != comparisonError.Code)
            throw new ShouldAssertException($"{nameof(Error.Code)} should be {comparisonError.Code}, but it is {error.Code}");
        
        if (error.Message != comparisonError.Message)
            throw new ShouldAssertException($"{nameof(Error.Message)} should be {comparisonError.Message}, but it is {error.Message}");
    }
}
