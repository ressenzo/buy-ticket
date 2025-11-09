using System.Data;
using BuyTicket.Infrastructure.Factories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BuyTicket.Infrastructure.Factories;

public class NpgsqlConnectionFactory(
    IConfiguration configuration) : IConnectionFactory
{
    private const string _CONNECTION_STRING = "Postgres";

    private readonly string _connectionString = configuration.GetConnectionString(_CONNECTION_STRING) ??
        throw new InvalidOperationException($"Connection string {_CONNECTION_STRING} not found");

    public IDbConnection CreateConnection() =>
        new NpgsqlConnection(_connectionString);
}
