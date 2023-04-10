using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services;
using ProductlineApp.Domain.Aggregates.Product.Repository;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Files;
using System.Security.Authentication;
using ProductlineApp.Application.Common.Services.Interfaces;

namespace ProductlineApp.Application.Product.Commands;

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
            this.RuleFor(x => x.UserId).NotEmpty();
            this.RuleFor(x => x.ProductId).NotEmpty();
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
            var isUserExisting = await this._userRepository.IsUserExistingAsync(request.UserId);

            if (!isUserExisting)
            {
                throw new Exception("No such user");
            }

            var product = await this._productRepository.GetByIdAsync(ProductId.Create(request.ProductId));

            if (!product.IsOwnerConsistent(UserId.Create(request.UserId)))
            {
                throw new AuthenticationException("Unauthorized to view product");
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
