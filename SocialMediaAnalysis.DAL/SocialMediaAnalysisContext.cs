using Microsoft.EntityFrameworkCore;

namespace SocialMediaAnalysis.DAL;

public class SocialMediaAnalysisContext : DbContext
{
    // public DbSet<SomeEntity> SomeEntities { get; set; }

    public SocialMediaAnalysisContext() : base()
    {
    }

    public SocialMediaAnalysisContext(DbContextOptions<SocialMediaAnalysisContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.ApplyConfiguration(new SomeEntityConfiguration());

        // + Data seeding?
    }
}
