using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

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
            builder.ToTable("User");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasConversion(
                    v => v.Value,
                    v => UserId.Create(v))
                .IsRequired();

            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            // builder.HasMany(e => e.PlatformConnections)
            //     .WithOne()
            //     .HasForeignKey(pc => pc.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // builder.OwnsMany(e => e.Roles, r =>
            // {
            //     r.WithOwner().HasForeignKey("UserId");
            //     r.ToTable("UserRole");
            //     r.HasKey("UserId", "RoleName");
            // });
            //
            // builder.HasData(
            //     new UserEntity
            //     {
            //         Id = UserId.Create(new Guid("9e3062d2-964a-4f8d-91a4-0a0aa7074d3b")),
            //         Username = "john",
            //         HashedPassword = "password123",
            //         Salt = "213323joi",
            //         Email = "john@example.com",
            //     });
    }

    private void ConfigurePlatformConnectionsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(e => e.PlatformConnections, ba =>
        {
            ba.ToTable("PlatformConnection");
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
        });
    }
}
