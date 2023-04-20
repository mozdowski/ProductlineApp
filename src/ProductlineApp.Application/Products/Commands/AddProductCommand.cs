using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.Products.Commands;

public class AddProductCommand
{
    public record Command(
        string Sku,
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
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x => x.Category).NotEmpty();
            this.RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.UserId).NotEmpty();
            this.RuleFor(x => x.Sku).NotEmpty();
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUploadFileService _uploadFileService;

        public Handler(
            IProductRepository productRepository,
            IUploadFileService uploadFileService)
        {
            this._productRepository = productRepository;
            this._uploadFileService = uploadFileService;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var image = await this._uploadFileService.UploadFileAsync(request.ImageFile, FileType.IMAGE);

            if (image is null)
            {
                throw new Exception("Failed to upload an image");
            }

            var product = Domain.Aggregates.Products.Product.Create(
                request.Sku,
                request.Name,
                request.Category,
                request.Price,
                request.Quantity,
                (Image)image,
                request.BrandName,
                request.Description,
                UserId.Create(request.UserId));

            await this._productRepository.AddAsync(product);

            return Unit.Value;
        }
    }
}
