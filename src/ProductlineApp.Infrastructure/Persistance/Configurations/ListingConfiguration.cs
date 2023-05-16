using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Domain.Aggregates.Listing;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Configurations;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        this.ConfigureListingsTable(builder);
        this.ConfigureListingInstanceTable(builder);
    }

    private void ConfigureListingsTable(EntityTypeBuilder<Listing> builder)
    {
            builder.ToTable("Listings");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasConversion(
                    v => v.Value,
                    v => ListingId.Create(v))
                .IsRequired();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.Quantity)
                .IsRequired();

            builder.Property(pc => pc.OwnerId)
                .HasConversion(
                    v => v.Value,
                    v => UserId.Create(v))
                .IsRequired();

            builder.Property(pc => pc.ProductId)
                .HasConversion(
                    v => v.Value,
                    v => ProductId.Create(v))
                .IsRequired();

            builder.Property(e => e.LastModified)
                .HasConversion(
                    v => v.Value.ToUniversalTime(),
                    v => v.ToUniversalTime());
    }

    private void ConfigureListingInstanceTable(EntityTypeBuilder<Listing> builder)
    {
        builder.OwnsMany(e => e.Instances, ba =>
        {
            ba.ToTable("ListingInstances");

            ba.WithOwner().HasForeignKey(li => li.ListingId);

            ba.Property(li => li.Id)
                .HasConversion(
                    v => v.Value,
                    v => ListingInstanceId.Create(v));

            ba.HasKey(li => li.Id);

            ba.Property(li => li.ListingId)
                .HasConversion(
                    v => v.Value,
                    v => ListingId.Create(v))
                .IsRequired();

            ba.Property(li => li.PlatformId)
                .HasConversion(
                    v => v.Value,
                    v => PlatformId.Create(v))
                .IsRequired();

            ba.Property(li => li.PlatformListingId)
                .IsRequired()
                .HasMaxLength(100);

            ba.Property(li => li.ExpiresIn);

            ba.Property(li => li.Status)
                .HasConversion<string>()
                .IsRequired();

            ba.Property(li => li.ListingUrl)
                .HasMaxLength(500);

            ba.Property(e => e.LastModified)
                .HasConversion(
                    v => v.Value.ToUniversalTime(),
                    v => v.ToUniversalTime());
        });
    }
}
