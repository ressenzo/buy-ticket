using BuyTicket.Event.Application.CreateEvent;
using BuyTicket.Event.Application.Factories;
using BuyTicket.Event.Application.Factories.Interfaces;
using BuyTicket.Event.Application.GetEvent;
using Microsoft.Extensions.DependencyInjection;

namespace BuyTicket.Event.Application;

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
