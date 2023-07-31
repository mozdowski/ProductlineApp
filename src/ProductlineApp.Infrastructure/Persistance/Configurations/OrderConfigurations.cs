using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Domain.Aggregates.Order;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        this.ConfigureOrdersTable(builder);
        this.ConfigureOrderLineTable(builder);
        this.ConfigureOrderDocumentsTable(builder);
    }

    private void ConfigureOrderDocumentsTable(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(p => p.Documents, doc =>
        {
            doc.WithOwner().HasForeignKey(x => x.OrderId);
            doc.HasKey(li => li.Id);
            doc.Property(e => e.Id)
                .HasConversion(
                    v => v.Value,
                    v => DocumentId.Create(v))
                .IsRequired();
            doc.Property(p => p.Name).IsRequired().HasMaxLength(255);
            doc.Property(p => p.Url)
                .HasConversion(
                    v => v.ToString(),
                    v => new Uri(v))
                .HasColumnName("DocumentUrl")
                .HasColumnType("varchar(500)")
                .IsRequired();
        });
    }

    private void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
    {
            builder.ToTable("Orders");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasConversion(
                    v => v.Value,
                    v => OrderId.Create(v))
                .IsRequired();

            builder.OwnsOne(o => o.ShippingAddress, sa =>
            {
                sa.Property(a => a.Address).HasConversion(
                    v => v.ToString(),
                    v => new Address(v)).HasColumnName("ShippingAddress_Address").HasMaxLength(500);
                sa.Property(a => a.FirstName).HasColumnName("ShippingAddress_Firstname").HasMaxLength(255).IsRequired(false);
                sa.Property(a => a.LastName).HasColumnName("ShippingAddress_Lastname").HasMaxLength(255).IsRequired(false);
                sa.Property(a => a.PhoneNumber).HasColumnName("ShippingAddress_Phone").HasMaxLength(255).IsRequired(false);
            });

            builder.OwnsOne(o => o.BillingAddress, ba =>
                {
                    ba.Property(a => a.Address).HasConversion(
                        v => v.ToString(),
                        v => new Address(v)).HasColumnName("BillingAddress_Address").HasMaxLength(500);
                    ba.Property(a => a.FirstName).HasColumnName("BillingAddress_Firstname").HasMaxLength(255).IsRequired(false);
                    ba.Property(a => a.LastName).HasColumnName("BillingAddress_Lastname").HasMaxLength(255).IsRequired(false);
                    ba.Property(a => a.Email).HasColumnName("BillingAddress_Email").HasMaxLength(255).IsRequired(false);
                    ba.Property(a => a.Username).HasColumnName("BillingAddress_Username").HasMaxLength(255).IsRequired(false);
                    ba.Property(a => a.PhoneNumber).HasColumnName("BillingAddress_Phone").HasMaxLength(255).IsRequired(false);
                });

            builder.Property(pc => pc.OwnerId)
                .HasConversion(
                    v => v.Value,
                    v => UserId.Create(v))
                .IsRequired();

            builder.Property(e => e.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.PlatformOrderId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PlacedAt)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => v.ToUniversalTime())
                .IsRequired();

            builder.Property(e => e.IsPaid)
                .IsRequired();

            builder.Property(e => e.SubtotalPrice)
                .IsRequired();

            builder.Property(e => e.DeliveryCost)
                .IsRequired();

            builder.Property(e => e.DeliveryDate)
                .HasConversion(
                    v => v.Value.ToUniversalTime(),
                    v => v.ToUniversalTime());

            builder.Property(e => e.PlatformId)
                .HasConversion(
                    v => v.Value,
                    v => PlatformId.Create(v))
                .IsRequired();

            builder.Property(e => e.LastModified)
                .HasConversion(
                    v => v.Value.ToUniversalTime(),
                    v => v.ToUniversalTime());

            builder.HasIndex(e => e.OwnerId);
            builder.HasIndex(e => e.PlatformId);
            builder.HasIndex(e => e.PlacedAt);
            builder.HasIndex(e => e.PlatformOrderId);
    }

    private void ConfigureOrderLineTable(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(e => e.OrderLines, ol =>
        {
            ol.ToTable("OrderLines");

            ol.Property(li => li.Id)
                .HasConversion(
                    v => v.Value,
                    v => OrderLineId.Create(v));

            ol.HasKey(li => li.Id);

            ol.Property(li => li.Price)
                .IsRequired();

            ol.Property(li => li.Sku)
                .IsRequired()
                .HasMaxLength(255);

            ol.Property(li => li.Name)
                .IsRequired()
                .HasMaxLength(255);

            ol.Property(li => li.Quantity)
                .IsRequired();

            ol.Property(e => e.LastModified)
                .HasConversion(
                    v => v.Value.ToUniversalTime(),
                    v => v.ToUniversalTime());

            ol.HasIndex(li => li.Sku);
        });
    }
}
