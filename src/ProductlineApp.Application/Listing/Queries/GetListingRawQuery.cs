using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Listing.Queries;

internal class GetListingRawQuery
{
    public record Query(
        Guid UserId,
        Guid ListingId) : IQuery<Domain.Aggregates.Listing.Listing>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ListingId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, Domain.Aggregates.Listing.Listing>
    {
        private readonly IListingRepository _listingRepository;

        public Handler(
            IListingRepository listingRepository,
            IMapper mapper)
        {
            this._listingRepository = listingRepository;
        }

        public async Task<Domain.Aggregates.Listing.Listing> Handle(Query request, CancellationToken cancellationToken)
        {
            var listing = await this._listingRepository.GetByIdAsync(ListingId.Create(request.ListingId));
            if (listing is null) throw new Exception($"Listing with ID: {request.ListingId} not found");

            if (!listing.IsUserConsistent(UserId.Create(request.UserId)))
            {
                throw new UnauthorizedAccessException(
                    $"User {request.UserId} has no rights for the listing {request.ListingId}");
            }

            return listing;
        }
    }
}
