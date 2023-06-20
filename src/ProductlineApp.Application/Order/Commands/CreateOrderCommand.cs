using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Application.Order.Commands;

public class CreateOrderCommand
{
    public record Command(
        Guid UserId,
        IEnumerable<OrderItemDto> OrderLines,
        ShippingAddress ShippingAddress,
        BillingAddress BillingAddress,
        Guid PlatformId,
        string PlatformOrderId,
        OrderStatus Status,
        DateTime PlacedAt,
        bool IsPaid,
        decimal SubtotalPrice,
        decimal DeliveryCost,
        DateTime? DeliveryDate) : IResultCommand<Guid>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.OrderLines).NotEmpty();
            this.RuleFor(x => x.ShippingAddress).NotEmpty();
            this.RuleFor(x => x.BillingAddress).NotEmpty();
            this.RuleFor(x => x.PlatformId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.PlatformOrderId).NotEmpty();
            this.RuleFor(x => x.Status).IsInEnum();
            this.RuleFor(x => x.PlacedAt).NotEmpty().LessThan(DateTime.Now);
            this.RuleFor(x => x.SubtotalPrice).NotEmpty().GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.DeliveryCost).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }

    public class Handler : IResultCommandHandler<Command, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(
            IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = UserId.Create(request.UserId);
            var platformId = PlatformId.Create(request.PlatformId);

            var isAlreadySaved = await this._orderRepository.IsAnyByPlatformOrderId(userId, platformId, request.PlatformOrderId);

            if (isAlreadySaved)
            {
                return Guid.Empty;
            }

            var orderLines = request.OrderLines.Select(x => OrderLine.Create(
                x.OrderItemId,
                x.Sku,
                x.Quantity,
                x.UnitPrice,
                x.Name));

            var order = Domain.Aggregates.Order.Order.Create(
                userId,
                orderLines,
                request.ShippingAddress,
                request.BillingAddress,
                platformId,
                request.PlatformOrderId,
                request.Status,
                request.PlacedAt,
                request.IsPaid,
                request.SubtotalPrice,
                request.DeliveryCost,
                request.DeliveryDate.HasValue ? request.DeliveryDate.Value : null);

            await this._orderRepository.AddAsync(order);
            return order.Id.Value;
        }
    }
}
