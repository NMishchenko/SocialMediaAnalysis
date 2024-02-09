using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialMediaAnalysis.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    const string SocialMediaAnalysis = "SocialMediaAnalysis";

    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);

        return services;
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SocialMediaAnalysisContext>(
            options => options.UseSqlServer(configuration.GetConnectionString(SocialMediaAnalysis)));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        // services.AddScoped<ISomeEntityRepository, SomeEntityRepository>();
    }
}