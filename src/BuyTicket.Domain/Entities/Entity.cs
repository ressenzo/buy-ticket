using BuyTicket.Domain.Entities.Interfaces;

namespace BuyTicket.Domain.Entities;

public abstract class Entity : IEntity
{
    public Entity() =>
        Id = Guid.NewGuid().ToString()[..8];

    public Entity(string id) => 
        Id = id;

    public string Id { get; }

    public abstract bool IsValid();
}