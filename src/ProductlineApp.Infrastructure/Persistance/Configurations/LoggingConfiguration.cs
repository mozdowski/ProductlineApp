using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductlineApp.Infrastructure.Logging;

namespace ProductlineApp.Infrastructure.Persistance.Configurations;

public class LoggingConfiguration : IEntityTypeConfiguration<LogEntity>
{
    public void Configure(EntityTypeBuilder<LogEntity> builder)
    {
        this.ConfigureLogEntityTable(builder);
    }

    private void ConfigureLogEntityTable(EntityTypeBuilder<LogEntity> builder)
    {
            builder.ToTable("Logging");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.Timestamp)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => v.ToUniversalTime());

            builder.Property(pc => pc.Severity)
                .HasConversion<string>()
                .IsRequired();
    }
}
