using MediatR;
using MediatrPolly.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace MediatrPolly.Extensions;

internal static class ContainerExtensions
{

    public static IServiceCollection ConfigureStartUp(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.ConfigureMediatr();
        services.AddHealthChecks();
        return services;
    }

    public static IServiceCollection ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }

    public static IServiceCollection ConfigureExchangeRateService(this IServiceCollection services, IConfiguration config)
    {
        services.TryAddSingleton<IExchangeRateService, ExchangeRateService>();

        var apiKey = config["ExchangeRateApiKey"];

        services.AddHttpClient<IExchangeRateService, ExchangeRateService>(client =>
        {
            client.BaseAddress = new Uri($"https://v6.exchangerate-api.com/v6/{apiKey}");
        });

        return services;
    }
}
