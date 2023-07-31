using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        this.ConfigureUsersTable(builder);
        this.ConfigurePlatformConnectionsTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasConversion(
                    v => v.Value,
                    v => UserId.Create(v))
                .IsRequired();

            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Avatar)
                .HasConversion(
                    v => v == null ? null : v.Url.ToString(),
                    v => string.IsNullOrEmpty(v) ? null : Image.Create(v));

            builder.Property(e => e.LastModified)
                .HasConversion(
                    v => DateTime.UtcNow,
                    v => v.ToUniversalTime());

            builder.HasIndex(e => e.Email);
    }

    private void ConfigurePlatformConnectionsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(e => e.PlatformConnections, ba =>
        {
            ba.ToTable("PlatformConnections");
            ba.WithOwner().HasForeignKey(pc => pc.UserId);
            ba.Property(pc => pc.Id)
                .HasConversion(
                    v => v.Value,
                    v => PlatformConnectionId.Create(v));
            ba.HasKey(pc => pc.Id);
            ba.Property(pc => pc.UserId)
                .HasConversion(
                    v => v.Value,
                    v => UserId.Create(v))
                .IsRequired();
            ba.Property(pc => pc.PlatformId)
                .HasConversion(
                    v => v.Value,
                    v => PlatformId.Create(v))
                .IsRequired();
            ba.Property(pc => pc.AccessToken)
                .IsRequired();
            ba.Property(pc => pc.RefreshToken)
                .IsRequired();
            ba.Property(pc => pc.ExpirationDate)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => v.ToUniversalTime())
                .IsRequired();
            ba.Property(pc => pc.RefreshTokenExpirationDate)
                .HasConversion(
                    v => v.Value.ToUniversalTime(),
                    v => v.ToUniversalTime());

            ba.Property(e => e.LastModified)
                .HasConversion(
                    v => v.Value.ToUniversalTime(),
                    v => v.ToUniversalTime());
        });
    }
}
