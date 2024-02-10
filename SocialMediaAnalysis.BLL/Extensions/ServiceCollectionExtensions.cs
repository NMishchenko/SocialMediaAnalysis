using Microsoft.Extensions.DependencyInjection;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Handlers;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Interfaces;
using SocialMediaAnalysis.BLL.Options;

namespace SocialMediaAnalysis.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessLogicLayerServices(this IServiceCollection services)
    {
        services.AddApiClients();
        services.AddOptions();
    }

    private static void AddApiClients(this IServiceCollection services)
    {
        services.AddTransient<RetryHttpHandler>();
        services.AddTransient<ExceptionHttpHandler>();
        services.AddTransient<AuthorizationHttpHandler>();

        services.AddHttpClient<INewsApiService, NewsApiService>()
            .AddHttpMessageHandler<RetryHttpHandler>()
            .AddHttpMessageHandler<ExceptionHttpHandler>()
            .AddHttpMessageHandler<AuthorizationHttpHandler>();
    }

    private static void AddOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<NewsApiAuthOptionsSetup>();
    }
}