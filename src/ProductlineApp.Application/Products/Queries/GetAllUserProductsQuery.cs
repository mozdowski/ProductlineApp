using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Mappings;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Products.Queries;

public class GetAllUserProductsQuery
{
    public record Query(Guid UserId) : IQuery<GetProductsResponse>;

    public class Handler : IQueryHandler<Query, GetProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IListingRepository _listingRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public Handler(
            IProductRepository productRepository,
            IUserRepository userRepository,
            IListingRepository listingRepository,
            IPlatformRepository platformRepository,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            this._userRepository = userRepository;
            this._listingRepository = listingRepository;
            this._platformRepository = platformRepository;
            this._mapper = mapper;
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            }
        }

        public async Task<GetProductsResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var isUserExisting = await this._userRepository.IsUserExistingAsync(UserId.Create(request.UserId));

            if (!isUserExisting)
            {
                throw new Exception($"No such user with id: {request.UserId}");
            }

            var products = await this._productRepository.GetAllByUserIdAsync(
                UserId.Create(request.UserId));

            var productPlatformsDictionary = await this._listingRepository
                .GetPlatformsProductsAreListedOn(products.Select(x => x.Id));

            var allPlatformsIds = productPlatformsDictionary
                .SelectMany(x => x.Value)
                .Distinct();

            var platformNames = await this._platformRepository.GetPlatformNamesByIdsAsync(allPlatformsIds);

            var productResponseMapperInputs = (from product in products let platforms = productPlatformsDictionary[product.Id].Select(x => platformNames[x]).ToList() select new ProductResponseMapperInput(product, platforms)).ToList();

            var mappedProducts = this._mapper.Map<List<ProductWithPlatformsDtoResponse>>(productResponseMapperInputs);

            return new GetProductsResponse(mappedProducts.ToList());
        }
    }
}
