using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;

namespace ProductlineApp.Application.Order.Queries;

public class GetOrderDocumentsQuery
{
    public record Query(
        Guid UserId,
        Guid OrderId) : IQuery<OrderDocumentsResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.OrderId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, OrderDocumentsResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<OrderDocumentsResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var order = await this._orderRepository.GetByIdAsync(OrderId.Create(request.OrderId));

            if (order is null)
            {
                throw new Exception($"Order with ID: {request.OrderId} not found");
            }

            return new OrderDocumentsResponse()
            {
                OrderDocuments = order.Documents.Select(x => new OrderDocumentsResponse.OrderDocumentResponse()
                {
                    Id = x.Id.Value,
                    Name = x.Name,
                    Url = x.Url.ToString(),
                }),
            };
        }
    }
}
