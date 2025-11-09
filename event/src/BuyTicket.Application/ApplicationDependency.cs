using BuyTicket.Application.CreateEvent;
using BuyTicket.Application.Factories;
using BuyTicket.Application.Factories.Interfaces;
using BuyTicket.Application.GetEvent;
using Microsoft.Extensions.DependencyInjection;

namespace BuyTicket.Application;

public static class ApplicationDependency
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateEventUseCase, CreateEventUseCase>();
        services.AddScoped<IGetEventUseCase, GetEventUseCase>();

        services.AddScoped<IEventFactory, EventFactory>();
        return services;
    }
}
