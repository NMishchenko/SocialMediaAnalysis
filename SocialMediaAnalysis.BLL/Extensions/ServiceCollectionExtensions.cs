using Microsoft.Extensions.DependencyInjection;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Handlers;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Interfaces;
using SocialMediaAnalysis.BLL.Options;
using SocialMediaAnalysis.BLL.Services;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessLogicLayerServices(this IServiceCollection services)
    {
        services.AddServices();
        services.AddApiClients();
        services.AddOptions();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAnalysisService, AnalysisService>();
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