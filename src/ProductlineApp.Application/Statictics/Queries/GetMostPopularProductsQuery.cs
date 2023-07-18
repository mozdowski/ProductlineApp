using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Statictics.DTO;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Statictics.Queries;

public class GetMostPopularProductsQuery
{
    public record Query(Guid UserId) : IQuery<MostPopularProductsDto>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, MostPopularProductsDto>
    {
        const int MostPopularProductsCount = 5;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public Handler(
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            this._orderRepository = orderRepository;
            this._productRepository = productRepository;
        }

        public async Task<MostPopularProductsDto> Handle(Query query, CancellationToken cancellationToken)
        {
            var productsIdsWithCount = await this._orderRepository.GetProductsIdsWithCountByUserIdAsync(UserId.Create(query.UserId));

            if (!productsIdsWithCount.Any())
            {
                return new MostPopularProductsDto()
                {
                    ProductsStatistics = new List<MostPopularProductsDto.ProductStatistics>(),
                };
            }

            List<MostPopularProductsDto.ProductStatistics> productStatisticsList = new();

            foreach (var productIdOrSku in productsIdsWithCount.Keys)
            {
                var product = await this._productRepository.GetProductsBySkuOrId(productIdOrSku);
                if (product is null) continue;

                productStatisticsList.Add(new MostPopularProductsDto.ProductStatistics()
                {
                    Name = product.Name,
                    SoldCount = productsIdsWithCount[productIdOrSku],
                });
            }

            return new MostPopularProductsDto()
            {
                ProductsStatistics = productStatisticsList
                    .OrderByDescending(x => x.SoldCount)
                    .Take(MostPopularProductsCount)
                    .ToList(),
            };
        }
    }
}
