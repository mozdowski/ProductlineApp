using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Listing.Commands;

public class CreateListingTemplateCommand
{
    public record Command(
        Guid UserId,
        string Title,
        string Description,
        Guid ProductId,
        decimal Price,
        int Quantity) : IResultCommand<CreateListingResponse>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ProductId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.Description).NotEmpty();
            this.RuleFor(x => x.Quantity).GreaterThan(0);
            this.RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.Title).NotEmpty();
        }
    }

    public class Handler : IResultCommandHandler<Command, CreateListingResponse>
    {
        private readonly IListingRepository _listingRepository;

        public Handler(
            IListingRepository listingRepository)
        {
            this._listingRepository = listingRepository;
        }

        public async Task<CreateListingResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            // Domain.Aggregates.Listing.Listing listing;

            // if (request.TakeProductDetails && request.ProductId.HasValue)
            // {
            //     var product = await this._productRepository.GetByIdAsync(ProductId.Create(request.ProductId.Value));
            //     if (product is null) throw new Exception($"Product with ID: {request.ProductId.Value} not found");
            //
            //     listing = Domain.Aggregates.Listing.Listing.CreateFromProduct(product, UserId.Create(request.UserId));
            //     await this._listingRepository.AddAsync(listing);
            //     return new CreateListingResponse()
            //     {
            //         ListingId = listing.Id.Value,
            //     };
            // }

            var listing = Domain.Aggregates.Listing.Listing.Create(
                    request.Title,
                    request.Description,
                    ProductId.Create(request.ProductId),
                    request.Price,
                    request.Quantity,
                    UserId.Create(request.UserId));

            await this._listingRepository.AddAsync(listing);

            return new CreateListingResponse()
            {
                ListingId = listing.Id.Value,
            };
        }
    }
}
