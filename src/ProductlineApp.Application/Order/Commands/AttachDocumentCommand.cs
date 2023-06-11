using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.Order.Commands;

public class AttachDocumentCommand
{
    public record Command(
        Guid UserId,
        Guid OrderId,
        IFormFile DocumentFile) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.OrderId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.DocumentFile).NotNull();
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUploadFileService _fileService;

        public Handler(
            IOrderRepository orderRepository,
            IUploadFileService fileService)
        {
            this._orderRepository = orderRepository;
            this._fileService = fileService;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var order = await this._orderRepository.GetByIdAsync(OrderId.Create(request.OrderId));

            if (order is null)
            {
                throw new Exception("No order found");
            }

            var document = await this._fileService.UploadFileAsync(request.DocumentFile, FileType.DOCUMENT);

            if (document is null)
            {
                throw new Exception("Failed to upload an image");
            }

            order.AddDocument((Document)document);

            await this._orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
