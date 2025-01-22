using BuyTicket.Domain.Commons;
using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Domain.Entities;

public abstract class Entity : IEntity
{
    private readonly List<Error> _errors;

    public Entity()
    {
        Id = Guid.NewGuid().ToString()[..8];
        _errors = [];
    }

    public Entity(string id)
    {
        Id = id;
        _errors = [];
    }

    public string Id { get; }

    public IReadOnlyCollection<Error> Errors => _errors;

    public abstract bool IsValid();

    public void AddError(Error error)
    {
        _errors.Add(error);
    }
}
