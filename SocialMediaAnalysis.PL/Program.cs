using Microsoft.EntityFrameworkCore;
using SocialMediaAnalysis.DAL;

namespace SocialMediaAnalysis.PL;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        startup.Configure(app, builder.Environment);

        // TODO: Do we need this? Auto applying the last migration, for this moment it doesn't work
        // using (var scope = app.Services.CreateScope())
        // {
        //     var context = scope.ServiceProvider.GetRequiredService<SocialMediaAnalysisContext>();
        //     await context.Database.MigrateAsync();
        // }

        await app.RunAsync();
    }
}
