using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;

namespace ProductlineApp.Application.Order.Commands;

public class DeleteDocumentCommand
{
    public record Command(
        Guid UserId,
        Guid OrderId,
        Guid DocumentId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.OrderId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.DocumentId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IUploadFileService _uploadFileService;
        private readonly IOrderRepository _orderRepository;

        public Handler(
            IUploadFileService uploadFileService,
            IOrderRepository orderRepository)
        {
            this._uploadFileService = uploadFileService;
            this._orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var order = await this._orderRepository.GetByIdAsync(OrderId.Create(request.OrderId));

            if (order is null)
            {
                throw new Exception("No order found");
            }

            var document = order.GetDocumentById(DocumentId.Create(request.DocumentId));

            await this._uploadFileService.DeleteFileAsync(document.Name);

            order.RemoveDocument(document);

            await this._orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
