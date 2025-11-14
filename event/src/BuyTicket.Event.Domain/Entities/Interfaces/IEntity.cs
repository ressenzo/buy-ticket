using BuyTicket.Event.Domain.Commons;

namespace BuyTicket.Event.Domain.Entities.Interfaces;

public interface IEntity
{
    string Id { get; }

    bool IsValid();

    public IReadOnlyCollection<Error> Errors { get; }

    protected void AddError(Error error);
}
