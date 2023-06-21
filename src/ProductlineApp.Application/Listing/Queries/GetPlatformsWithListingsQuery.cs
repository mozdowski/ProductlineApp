using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Listing.Queries;

public class GetPlatformsWithListingsQuery
{
    public record Query(Guid UserId) : IQuery<GetPlatformsWithAuctionsResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, GetPlatformsWithAuctionsResponse>
    {
        private readonly IListingRepository _listingRepository;
        private readonly IPlatformRepository _platformRepository;

        public Handler(
            IListingRepository listingRepository,
            IPlatformRepository platformRepository)
        {
            this._listingRepository = listingRepository;
            this._platformRepository = platformRepository;
        }

        public async Task<GetPlatformsWithAuctionsResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var platformIds = await this._listingRepository.GetPlatformsUserHasListingsOn(UserId.Create(request.UserId));
            var platforms = await this._platformRepository.GetPlatformNamesByIdsAsync(platformIds);

            var platformsResponse = platforms.Keys.Select(x => new PlatformResponse()
            {
                Id = x.Value,
                Name = Enum.Parse<PlatformNames>(platforms[x].ToUpper()),
            });

            return new GetPlatformsWithAuctionsResponse()
            {
                Platforms = platformsResponse,
            };
        }
    }
}
