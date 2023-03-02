using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Entities;

namespace ProductlineApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    AggregationRootDbSet<Seller> Sellers { get; }

    AggregationRootDbSet<Order> Orders { get; }

    AggregationRootDbSet<Auction> Auctions { get; }

    AggregationRootDbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
