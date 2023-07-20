using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                v => v.Value,
                v => ProductId.Create(v))
            .IsRequired();

        builder.OwnsOne(p => p.Category, category =>
        {
            category.Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();
        });

        builder.OwnsMany(p => p.Gallery, gallery =>
        {
            gallery.WithOwner().HasForeignKey("ProductId");
            gallery.Property(p => p.Url)
                .HasConversion(
                    v => v.ToString(),
                    v => new Uri(v))
                .HasColumnName("ImageUrl")
                .HasColumnType("varchar(800)")
                .IsRequired();
        });

        builder.OwnsOne(p => p.Brand, b =>
        {
            b.Property(x => x.Name).IsRequired().HasMaxLength(100);
        });

        builder.OwnsOne(p => p.Image, img =>
        {
            img.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            img.Property(x => x.Url)
                .HasConversion(
                    v => v.ToString(),
                    v => new Uri(v))
                .HasColumnType("varchar(800)")
                .IsRequired();
        });

        builder.Property(p => p.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.Quantity)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(800)
            .IsRequired();

        builder.Property(p => p.OwnerId)
            .HasConversion(
                v => v.Value,
                v => UserId.Create(v))
            .IsRequired();

        builder.Property(p => p.Sku)
            .HasMaxLength(255).IsRequired();

        builder.Property(p => p.IsListed)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.LastModified)
            .HasConversion(
                v => DateTime.UtcNow,
                v => v.ToUniversalTime());
    }
}
