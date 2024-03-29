using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductlineApp.Domain.Aggregates.Listing;
using ProductlineApp.Domain.Aggregates.Order;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Infrastructure.Logging;

namespace ProductlineApp.Infrastructure.Persistance;

public class ProductlineDbContext : DbContext
{
    public ProductlineDbContext(DbContextOptions<ProductlineDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Listing> Listings { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<LogEntity> Logs { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        foreach (var entry in this.ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.LastModified = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductlineDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

public class ProductlineDbContextFactory : IDesignTimeDbContextFactory<ProductlineDbContext>
{
    public ProductlineDbContextFactory()
    {
    }

    public ProductlineDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductlineDbContext>();

        optionsBuilder.UseNpgsql("connection-string");

        return new ProductlineDbContext(optionsBuilder.Options);
    }
}
