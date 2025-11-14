namespace BuyTicket.Event.Domain.Commons;

public abstract class Validator
{
    private readonly List<Error> _errors;

    public Validator()
    {
        _errors = [];
    }

    public IReadOnlyCollection<Error> Errors => _errors;

    public abstract bool IsValid();

    public void AddError(Error error)
    {
        _errors.Add(error);
    }
}
