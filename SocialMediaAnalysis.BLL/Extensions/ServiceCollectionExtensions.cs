using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaAnalysis.BLL.HttpHandlers;
using SocialMediaAnalysis.BLL.Options;
using SocialMediaAnalysis.BLL.Services;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessLogicLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddServices();
        services.AddApiClients();
        services.AddOptions();
        services.AddTextAnalyticsClient(configuration);
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAnalysisService, AnalysisService>();
        services.AddTransient<INlpService, NlpService>();
        services.AddTransient<IRssFeedService, RssFeedService>();
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
        services.ConfigureOptions<ApplicationOptionsSetup>();
        services.ConfigureOptions<NlpOptions>();
    }

    private static void AddTextAnalyticsClient(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var azureKey = configuration.GetSection("NlpSettings:AzureKey").Value!;
        var azureEndpoint = configuration.GetSection("NlpSettings:AzureEndpoint").Value!;
        
        AzureKeyCredential credentials = new(azureKey);
        Uri endpoint = new(azureEndpoint);
        
        var textAnalyticsClient = new TextAnalyticsClient(endpoint, credentials);
        services.AddSingleton(_ => textAnalyticsClient);
    }
}