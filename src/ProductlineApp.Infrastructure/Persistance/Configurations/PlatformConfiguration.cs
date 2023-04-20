using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Infrastructure.Persistance.Entities.Platform;

namespace ProductlineApp.Infrastructure.Persistance.Configurations;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.ToTable("Platform");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                v => v.Value,
                v => PlatformId.Create(v))
            .IsRequired();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new PlatformEntity(PlatformId.Create(Guid.NewGuid()), "ebay", $"https://www.ebay.com/"));

        builder.HasData(
            new PlatformEntity(PlatformId.Create(Guid.NewGuid()), "allegro", $"https://allegro.pl/"));

        builder.HasData(
            new PlatformEntity(PlatformId.Create(Guid.NewGuid()), "amazon", $"https://amazon.com/"));
    }
}
