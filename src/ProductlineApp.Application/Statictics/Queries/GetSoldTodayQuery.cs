using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Statictics.DTO;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Statictics.Queries;

public class GetSoldTodayQuery
{
    public record Query(Guid UserId) : IQuery<SoldTodayDto>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, SoldTodayDto>
    {
        const int SoldTodayProductsCount = 5;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public Handler(
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            this._orderRepository = orderRepository;
            this._productRepository = productRepository;
        }

        public async Task<SoldTodayDto> Handle(Query query, CancellationToken cancellationToken)
        {
            var productsIdsWithCount = await this._orderRepository.GetTodayProductsIdsWithCountByUserIdAsync(UserId.Create(query.UserId));

            if (!productsIdsWithCount.Any())
            {
                return new SoldTodayDto()
                {
                    ProductsStatistics = new List<ProductStatistics>(),
                };
            }

            List<ProductStatistics> productStatisticsList = new();

            foreach (var productIdOrSku in productsIdsWithCount.Keys)
            {
                var product = await this._productRepository.GetProductsBySkuOrId(productIdOrSku);
                if (product is null) continue;

                productStatisticsList.Add(new ProductStatistics()
                {
                    Name = product.Name,
                    SoldCount = productsIdsWithCount[productIdOrSku],
                });
            }

            return new SoldTodayDto()
            {
                ProductsStatistics = productStatisticsList
                    .OrderByDescending(x => x.SoldCount)
                    .Take(SoldTodayProductsCount)
                    .ToList(),
            };
        }
    }
}
