using System.Text;
using BuyTicket.Event.Domain.Entities.Interfaces;
using BuyTicket.Event.Infrastructure.Factories.Interfaces;
using BuyTicket.Event.Infrastructure.Models;
using BuyTicket.Event.Infrastructure.Repositories.Interfaces;
using Dapper;

namespace BuyTicket.Event.Infrastructure.Repositories;

internal sealed class EventRepository(
    IConnectionFactory connectionFactory) : IEventRepository
{
    private readonly IConnectionFactory _connectionFactory = connectionFactory;

    private const string _SELECT_QUERY = @"SELECT
        id as Id,
        name as Name,
        description as Description,
        start_date as StartDate,
        end_date as EndDate
        FROM
        events
        WHERE 1=1";

    public Task CreateEvent(
        IEvent @event,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEvent?> GetEvent(
        string id,
        CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        var query = new StringBuilder(_SELECT_QUERY);
        query.AppendLine(" AND id = @id");
        var @event = await connection.QueryFirstOrDefaultAsync<EventModel>(
            query.ToString(),
            new { id });
        return @event?.ToEntity();
    }
}
