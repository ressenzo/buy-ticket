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

    private const string _SELECT_QUERY = @$"SELECT
        id as {nameof(Domain.Entities.Event.Id)},
        name as {nameof(Domain.Entities.Event.Name)},
        description as {nameof(Domain.Entities.Event.Description)},
        start_date as {nameof(Domain.Entities.Event.StartDate)},
        end_date as {nameof(Domain.Entities.Event.EndDate)},
        address as {nameof(Domain.Entities.Event.Address)}
        FROM
        events
        WHERE 1=1";

    private const string _INSERT_QUERY = @"INSERT INTO
        events
        (
            id,
            name,
            description,
            start_date,
            end_date,
            address
        )
        VALUES
        (
            @id,
            @name,
            @description,
            @start_date,
            @end_date,
            @address
        )";

    public async Task CreateEvent(
        IEvent @event,
        CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        var query = new StringBuilder(_INSERT_QUERY);
        await connection.ExecuteAsync(
            query.ToString(),
            new
            {
                @event.Id,
                @event.Name,
                @event.Description,
                @start_date = @event.StartDate,
                @end_date = @event.EndDate,
                @event.Address
            });
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
