using BuyTicket.Domain.Entities.Interfaces;
using BuyTicket.Domain.ValueObjects;

namespace BuyTicket.Domain.Entities;

public class Event : Entity, IEvent
{
    private Event(string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        Address address)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Address = address;
    }

    private Event(string id,
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        Address address) : base(id)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Address = address;
    }

    public string Name { get; private set ;} = null!;

    public string Description { get; private set ;} = null!;

    public DateTime StartDate { get; private set ;}

    public DateTime EndDate { get; private set ;}

    public Address Address { get; private set; }

    public static IEvent Construct(string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        Address address) =>
        new Event(name,
            description,
            startDate,
            endDate,
            address);

    public static IEvent Construct(string id,
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        Address address) =>
        new Event(id,
            name,
            description,
            startDate,
            endDate,
            address);

    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}
