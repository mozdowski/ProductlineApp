using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductlineApp.Domain.Common;

namespace ProductlineApp.Application.Common;

public class AggregationRootDbSet<TAggregationRoot> : DbSet<TAggregationRoot>
    where TAggregationRoot : AggregateRoot
{
    public override IEntityType EntityType { get; }
}
