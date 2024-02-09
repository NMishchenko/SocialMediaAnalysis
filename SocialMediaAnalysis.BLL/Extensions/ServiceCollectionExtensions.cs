using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SocialMediaAnalysis.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogicLayerServices(this IServiceCollection services)
    {
        AddMapper(services);
        AddValidators(services);
        AddServices(services);

        return services;
    }

    private static void AddMapper(IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            // mc.AddProfile(new SomeEntityMappingProfile());
        });

        services.AddSingleton(mappingConfig.CreateMapper());
    }

    private static void AddServices(IServiceCollection services)
    {
        // services.AddScoped<ISomeService, SomeService>();
    }

    private static void AddValidators(IServiceCollection services)
    {
        // services.AddScoped<IValidator<SomeModel>, SomeModelValidator>();
    }
}