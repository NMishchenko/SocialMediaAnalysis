using Microsoft.OpenApi.Models;

namespace SocialMediaAnalysis.PL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        AddSwagger(services);
        return services;
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "SocialMediaAnalysis API"});
        });
    }
}