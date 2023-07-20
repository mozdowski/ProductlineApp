using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Infrastructure.Persistance.Configurations;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.ToTable("Platforms");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                v => v.Value,
                v => PlatformId.Create(v))
            .IsRequired();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.LastModified)
            .HasConversion(
                v => DateTime.UtcNow,
                v => v.ToUniversalTime());

        builder.HasData(Platform.Create(PlatformNames.EBAY.ToString().ToLower()));
        builder.HasData(Platform.Create(PlatformNames.ALLEGRO.ToString().ToLower()));
    }
}
