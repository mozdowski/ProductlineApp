using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Listing.Queries;

public class GetUserListingsQuery
{
    public record Query(Guid UserId) : IQuery<GetUserListingsResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, GetUserListingsResponse>
    {
        private readonly IListingRepository _listingRepository;
        private readonly IMapper _mapper;

        public Handler(
            IListingRepository listingRepository,
            IMapper mapper)
        {
            this._listingRepository = listingRepository;
            this._mapper = mapper;
        }

        public async Task<GetUserListingsResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var listings = await this._listingRepository.GetAllByUserIdAsync(UserId.Create(request.UserId));
            return this._mapper.Map<GetUserListingsResponse>(listings);
        }
    }
}
