using Microsoft.EntityFrameworkCore;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Common;

namespace ProductlineApp.Application.Categories.Queries;

public class GetCategoryByIdQuery
{
    public record Query(Guid Id) : IQuery<Category>;

    public class Handler : IQueryHandler<Query, Category>
    {
        private readonly IApplicationDbContext _context;

        public Handler(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Category> Handle(Query request, CancellationToken cancellationToken)
        {
            return await this._context.Categories
                .FirstAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
