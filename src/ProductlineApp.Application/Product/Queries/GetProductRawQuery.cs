using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.Product.Repository;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using System.Security.Authentication;

namespace ProductlineApp.Application.Product.Queries;

public class GetProductRawQuery
{
    public record Query(
        Guid ProductId,
        Guid UserId) : IQuery<Domain.Aggregates.Product.Product>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty();
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : IQueryHandler<Query, Domain.Aggregates.Product.Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public Handler(
            IProductRepository productRepository,
            IUserRepository userRepository)
        {
            this._productRepository = productRepository;
            this._userRepository = userRepository;
        }

        public async Task<Domain.Aggregates.Product.Product> Handle(Query request, CancellationToken cancellationToken)
        {
            var isUserExisting = await this._userRepository.IsUserExistingAsync(request.UserId);

            if (!isUserExisting)
            {
                throw new Exception("No such user");
            }

            var product = await this._productRepository.GetByIdAsync(ProductId.Create(request.ProductId));

            if (!product.IsOwnerConsistent(UserId.Create(request.UserId)))
            {
                throw new AuthenticationException("Unauthorized to view product");
            }

            return product;
        }
    }
}
