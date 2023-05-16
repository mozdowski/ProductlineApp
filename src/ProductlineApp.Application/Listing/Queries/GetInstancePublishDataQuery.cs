using AutoMapper;
using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Listing.DTO;

namespace ProductlineApp.Application.Listing.Queries;

public class GetInstancePublishDataQuery
{
    public record Query(
        Guid ListingId,
        Guid ListingInstanceId,
        Guid UserId) : IQuery<ListingPublishDto>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.ListingId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ListingInstanceId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, ListingPublishDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public Handler(
            IMediator mediator,
            IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task<ListingPublishDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = new GetListingInstanceQuery.Query(request.ListingId, request.ListingInstanceId, request.UserId);
            var listingInstance = await this._mediator.Send(query, cancellationToken);

            return this._mapper.Map<ListingPublishDto>(listingInstance);
        }
    }
}
