using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using System.Security.Authentication;

namespace ProductlineApp.Application.Products.Commands;

public class DeleteImageFromGallery
{
    public record Command(
        string ImageName,
        Guid ProductId,
        Guid UserId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.ImageName).NotEmpty();
            this.RuleFor(x => x.ProductId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
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
            var product = await this._productRepository.GetByIdAsync(ProductId.Create(request.ProductId));

            if (product is null)
            {
                throw new Exception("Product not found");
            }

            if (!product.IsOwnerConsistent(UserId.Create(request.UserId)))
            {
                throw new AuthenticationException("Unauthorized to delete product");
            }

            product.RemoveImageFromGallery(request.ImageName);

            await this._uploadFileService.DeleteFileAsync(request.ImageName);

            return Unit.Value;
        }
    }
}
