using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Application.Products.Queries;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Application.Products.Commands;

public class DeleteProductCommand
{
    public record Command(
        Guid ProductId,
        Guid UserId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty();
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IUploadFileService _uploadFileService;

        public Handler(
            IProductRepository productRepository,
            IMediator mediator,
            IUploadFileService uploadFileService)
        {
            this._productRepository = productRepository;
            this._mediator = mediator;
            this._uploadFileService = uploadFileService;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var query = new GetProductRawQuery.Query(
                request.ProductId,
                request.UserId);
            var product = await this._mediator.Send(query);

            await this._productRepository.RemoveAsync(product);

            var imagesToRemove = product.Gallery
                .Concat(new List<Image> { product.Image })
                .Select(x => x.Name);

            await this._uploadFileService.DeleteMultiFilesAsync(imagesToRemove);

            return Unit.Value;
        }
    }
}
