using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Statictics.DTO;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Statictics.Queries;

public class GetWeeklySellingStatsQuery
{
    public record Query(Guid UserId) : IQuery<WeeklySellingStatsDto>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, WeeklySellingStatsDto>
    {
        const int WeekDaysCount = 7;
        private readonly IOrderRepository _orderRepository;

        public Handler(
            IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<WeeklySellingStatsDto> Handle(Query query, CancellationToken cancellationToken)
        {
            var userId = UserId.Create(query.UserId);
            var weeklySellsCount = await this._orderRepository.GetWeeklySellsCount(userId);

            return new WeeklySellingStatsDto()
            {
                WeeklySellingCount = weeklySellsCount,
            };
        }
    }
}
