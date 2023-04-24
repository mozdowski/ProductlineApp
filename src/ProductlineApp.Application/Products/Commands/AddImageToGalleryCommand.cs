using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Files;
using System.Security.Authentication;

namespace ProductlineApp.Application.Products.Commands;

public class AddImageToGalleryCommand
{
    public record Command(
        IFormFile ImageFile,
        Guid ProductId,
        Guid UserId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ProductId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ImageFile).NotNull();
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUploadFileService _uploadFileService;
        private readonly IUserRepository _userRepository;

        public Handler(
            IProductRepository productRepository,
            IUploadFileService uploadFileService,
            IUserRepository userRepository)
        {
            this._productRepository = productRepository;
            this._uploadFileService = uploadFileService;
            this._userRepository = userRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var isUserExisting = await this._userRepository.IsUserExistingAsync(UserId.Create(request.UserId));

            if (!isUserExisting)
            {
                throw new Exception("No such user");
            }

            var product = await this._productRepository.GetByIdAsync(ProductId.Create(request.ProductId));

            if (product is null)
            {
                throw new Exception("Product not found");
            }

            if (!product.IsOwnerConsistent(UserId.Create(request.UserId)))
            {
                throw new AuthenticationException("Unauthorized to view product");
            }

            if (product.HasGalleryReachedMaxCapacity())
            {
                throw new Exception("Max capacity of gallery has been reached");
            }

            var image = await this._uploadFileService.UploadFileAsync(request.ImageFile, FileType.IMAGE);

            if (image is null)
            {
                throw new Exception("Failed to upload an image");
            }

            product.AddImageToGallery((Image)image);

            await this._productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
