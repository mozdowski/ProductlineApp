using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Statictics.DTO;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Statictics.Queries;

public class GetAuctionStatisticsQuery
{
    public record Query(Guid UserId) : IQuery<AuctionStatisticsDto>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, AuctionStatisticsDto>
    {
        private readonly IListingRepository _listingRepository;

        public Handler(IListingRepository listingRepository)
        {
            this._listingRepository = listingRepository;
        }

        public async Task<AuctionStatisticsDto> Handle(Query query, CancellationToken cancellationToken)
        {
            var listings = await this._listingRepository.GetAllListingInstancesByUserIdAsync(UserId.Create(query.UserId));

            var activeListingsCount = listings.Count(x => x.IsActive());

            return new AuctionStatisticsDto()
            {
                ActiveAuctionsCount = activeListingsCount,
                AllAuctionsCount = listings.Count(),
            };
        }
    }
}
