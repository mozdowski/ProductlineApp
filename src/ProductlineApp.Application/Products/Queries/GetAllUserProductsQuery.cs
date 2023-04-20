using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Products.Queries;

public class GetAllUserProductsQuery
{
    public record Query(Guid UserId) : IQuery<GetProductsResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : IQueryHandler<Query, GetProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(
            IProductRepository productRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<GetProductsResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var isUserExisting = await this._userRepository.IsUserExistingAsync(request.UserId);

            if (!isUserExisting)
            {
                throw new Exception("No such user");
            }

            var products = await this._productRepository.GetAllByUserIdAsync(
                UserId.Create(request.UserId));

            var mappedProducts = this._mapper.Map<IEnumerable<ProductDto>>(products);

            return new GetProductsResponse(mappedProducts.ToList());
        }
    }
}
