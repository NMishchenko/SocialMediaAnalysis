﻿using SocialMediaAnalysis.BLL.Extensions;
using SocialMediaAnalysis.DAL.Extensions;
using SocialMediaAnalysis.PL.Extensions;
using SocialMediaAnalysis.PL.Middleware;

namespace SocialMediaAnalysis.PL;

public class Startup
{
    const string FrontOriginPolicyName = "SocialMediaAnalysisUI";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

        services.AddCors(options =>
        {
            options.AddPolicy(FrontOriginPolicyName, policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });       
        });
                
        services.AddEndpointsApiExplorer();
        
        services.AddDataAccessLayerServices(Configuration);
        services.AddBusinessLogicLayerServices(Configuration);
        services.AddPresentationLayer(Configuration);
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseCors(FrontOriginPolicyName);
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.MapControllers();
    }
}