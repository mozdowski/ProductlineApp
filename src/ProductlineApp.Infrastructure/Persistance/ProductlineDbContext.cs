using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.Entities;

namespace ProductlineApp.Infrastructure.Persistance;

public class ProductlineDbContext : DbContext
{
    public ProductlineDbContext(DbContextOptions<ProductlineDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Platform> Platforms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductlineDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
