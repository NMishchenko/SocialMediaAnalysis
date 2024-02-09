/*
using SocialMediaAnalysis.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaAnalysis.DAL.FluentConfigurations;

public class SomeEntityConfiguration : IEntityTypeConfiguration<SomeEntity>
{
    public void Configure(EntityTypeBuilder<SomeEntity> builder)
    {
        builder
            .HasOne(e => e.Parent)
            .WithMany(e => e.Child)
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasQueryFilter(e => !e.IsDeleted);
    }
}

THIS IS AN EXAMPLE OF THE FLUENT CONFIGURATION

*/