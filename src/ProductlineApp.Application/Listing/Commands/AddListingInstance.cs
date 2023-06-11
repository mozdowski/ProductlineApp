using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Listing.Queries;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Listing.Commands;

public class AddListingInstance
{
    public record Command(
        Guid UserId,
        Guid ListingId,
        Guid PlatformId,
        string PlatformListingId,
        string? ListingUrl,
        int? ExpiresIn) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ListingId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.PlatformId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.PlatformListingId).NotEmpty();
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IListingRepository _listingRepository;
        private readonly IMediator _mediator;

        public Handler(
            IListingRepository listingRepository,
            IMediator mediator)
        {
            this._listingRepository = listingRepository;
            this._mediator = mediator;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var query = new GetListingRawQuery.Query(
                request.UserId,
                request.ListingId);
            var listing = await this._mediator.Send(query, cancellationToken);

            listing.AddInstance(
                PlatformId.Create(request.PlatformId),
                request.PlatformListingId,
                request.ListingUrl,
                request.ExpiresIn);

            await this._listingRepository.UpdateAsync(listing);

            return Unit.Value;
        }
    }
}
