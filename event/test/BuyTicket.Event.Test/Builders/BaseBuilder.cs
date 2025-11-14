namespace BuyTicket.Event.Test.Builders;

public abstract class BaseBuilder<T> where T : notnull
{
    public abstract T Build();
}
