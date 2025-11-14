using System.Data;

namespace BuyTicket.Event.Infrastructure.Factories.Interfaces;

public interface IConnectionFactory
{
    IDbConnection CreateConnection();
}
