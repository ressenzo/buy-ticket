using BuyTicket.Infrastructure.Repositories;
using BuyTicket.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BuyTicket.Infrastructure;

public static class InfrastructureDependency
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IEventRepository, EventRepository>();
        return services;
    }
}
