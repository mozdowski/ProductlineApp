using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Order.Queries;

public class GetOfflineOrdersQuery
{
    public record Query(
        Guid UserId) : IQuery<IEnumerable<OrderDtoResponse>>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, IEnumerable<OrderDtoResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _platformRepository;

        public Handler(
            IOrderRepository orderRepository,
            IMapper mapper,
            IPlatformRepository platformRepository)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
            this._platformRepository = platformRepository;
        }

        public async Task<IEnumerable<OrderDtoResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var orders = await this._orderRepository.GetAllByUserIdAsync(UserId.Create(request.UserId));
            var platformDict = await this._platformRepository.GetPlatformNamesByIdsAsync(orders.Select(x => x.PlatformId));

            var response = new List<OrderDtoResponse>();
            foreach (var order in orders)
            {
                var mappedOrder = this._mapper.Map<OrderDtoResponse>(order);
                var platformEnum = Enum.Parse<PlatformNames>(platformDict[order.PlatformId].ToUpper());

                mappedOrder.Platform = platformEnum;
                response.Add(mappedOrder);
            }

            return response;
        }
    }
}
