namespace BuyTicket.Test.Builders;

public abstract class BaseBuilder<T> where T : notnull
{
    public abstract T Build();
}
