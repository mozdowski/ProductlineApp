using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;

namespace ProductlineApp.Application.Listing.Queries;

internal class GetListingInstanceQuery
{
    public record Query(
        Guid ListingId,
        Guid ListingInstanceId,
        Guid UserId) : IQuery<ListingInstance>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.ListingId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ListingInstanceId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, ListingInstance>
    {
        private readonly IMediator _mediator;

        public Handler(
            IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task<ListingInstance> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = new GetListingRawQuery.Query(request.UserId, request.ListingId);
            var listing = await this._mediator.Send(query, cancellationToken);

            var listingInstance =
                listing.Instances.FirstOrDefault(x => x.Id == ListingInstanceId.Create(request.ListingInstanceId));

            if (listingInstance is null)
                throw new Exception($"Listing instance with ID: {request.ListingInstanceId} not found");

            return listingInstance;
        }
    }
}
