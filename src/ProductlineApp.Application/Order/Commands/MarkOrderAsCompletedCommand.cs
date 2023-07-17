using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;

namespace ProductlineApp.Application.Order.Commands;

public class MarkOrderAsCompletedCommand
{
    public record Command(
        Guid OrderId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.OrderId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(
            IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var order = await this._orderRepository.GetByIdAsync(OrderId.Create(request.OrderId));

            if (order is null)
            {
                throw new Exception("No order found");
            }

            order.MarkAsCompleted();

            await this._orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
