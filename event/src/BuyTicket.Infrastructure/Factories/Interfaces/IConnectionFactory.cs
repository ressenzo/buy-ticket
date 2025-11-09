using System.Data;

namespace BuyTicket.Infrastructure.Factories.Interfaces;

public interface IConnectionFactory
{
    IDbConnection CreateConnection();
}
