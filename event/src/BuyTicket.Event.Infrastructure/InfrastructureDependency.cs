using BuyTicket.Event.Infrastructure.Factories;
using BuyTicket.Event.Infrastructure.Factories.Interfaces;
using BuyTicket.Event.Infrastructure.Repositories;
using BuyTicket.Event.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BuyTicket.Event.Infrastructure;

public static class InfrastructureDependency
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddSingleton<IConnectionFactory, NpgsqlConnectionFactory>();
        return services;
    }
}
