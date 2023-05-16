using AutoMapper;
using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Listing.DTO;

namespace ProductlineApp.Application.Listing.Queries;

public class GetListingByIdQuery
{
    public record Query(
        Guid UserId,
        Guid ListingId) : IQuery<ListingDtoResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ListingId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, ListingDtoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public Handler(
            IMapper mapper,
            IMediator mediator)
        {
            this._mapper = mapper;
            this._mediator = mediator;
        }

        public async Task<ListingDtoResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = new GetListingRawQuery.Query(request.UserId, request.ListingId);
            var listing = await this._mediator.Send(query, cancellationToken);

            return this._mapper.Map<ListingDtoResponse>(listing);
        }
    }
}
