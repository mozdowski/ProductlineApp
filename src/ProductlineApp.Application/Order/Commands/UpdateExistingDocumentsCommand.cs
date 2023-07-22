using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;

namespace ProductlineApp.Application.Order.Commands;

public class UpdateExistingDocumentsCommand
{
    public record Command(
        Guid UserId,
        Guid OrderId,
        List<Guid> DocumentIds) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.OrderId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUploadFileService _uploadFileService;

        public Handler(
            IOrderRepository orderRepository,
            IUploadFileService uploadFileService)
        {
            this._orderRepository = orderRepository;
            this._uploadFileService = uploadFileService;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var order = await this._orderRepository.GetByIdAsync(OrderId.Create(request.OrderId));

            if (order is null)
            {
                throw new Exception($"Order with ID: {request.OrderId} not found");
            }

            var documentsToRemove = order.Documents
                .Where(x => !request.DocumentIds.Contains(x.Id.Value))
                .ToList();

            var documentsRemovalTasks = new List<Task>();
            documentsToRemove.ForEach(x =>
            {
                documentsRemovalTasks.Add(this._uploadFileService.DeleteFileAsync(x.Name));
                order.RemoveDocument(x);
            });

            documentsRemovalTasks.Add(this._orderRepository.UpdateAsync(order));
            await Task.WhenAll(documentsRemovalTasks);

            return Unit.Value;
        }
    }
}
