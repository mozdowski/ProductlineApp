using Microsoft.EntityFrameworkCore;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Entities;

namespace ProductlineApp.Application.Sellers.Queries;

public class GetSellerByNicknameQuery
{
    public record Query(string Nickname) : IQuery<Seller>;

    public class Handler : IQueryHandler<Query, Seller>
    {
        private readonly IApplicationDbContext _context;

        public Handler(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Seller> Handle(Query request, CancellationToken cancellationToken)
        {
            return await this._context.Sellers
                .FirstAsync(
                    x => x.Nickname == request.Nickname,
                    cancellationToken: cancellationToken);
        }
    }
}
