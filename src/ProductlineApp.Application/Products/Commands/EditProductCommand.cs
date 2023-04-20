using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Application.Products.Queries;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.Products.Commands;

public class EditProductCommand
{
    public record Command(
        Guid ProductId,
        string Name,
        string Category,
        decimal Price,
        int Quantity,
        IFormFile ImageFile,
        string BrandName,
        string Description,
        Guid UserId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty();
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x => x.Category).NotEmpty();
            this.RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUploadFileService _uploadFileService;
        private readonly IMediator _mediator;

        public Handler(
            IProductRepository productRepository,
            IUploadFileService uploadFileService,
            IMediator mediator)
        {
            this._productRepository = productRepository;
            this._uploadFileService = uploadFileService;
            this._mediator = mediator;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var image = await this._uploadFileService.UploadFileAsync(request.ImageFile, FileType.IMAGE);

            if (image is null)
            {
                throw new Exception("Failed to upload an image");
            }

            var query = new GetProductRawQuery.Query(
                request.ProductId,
                request.UserId);

            var product = await this._mediator.Send(query, cancellationToken);

            product.Update(
                request.Name,
                request.Category,
                request.Price,
                (Image)image,
                request.Quantity,
                request.BrandName,
                request.Description);

            await this._productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
