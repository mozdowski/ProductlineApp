using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Application.Products.Queries;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Allegro;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.Products.Commands;

public class EditProductImageCommand
{
    public record Command(
        Guid UserId,
        Guid ProductId,
        IFormFile? ImageFile,
        string? ImageUrl) : IResultCommand<EditProductImageResponse>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.ImageFile)
                .NotNull().When(x => string.IsNullOrWhiteSpace(x.ImageUrl));
            this.RuleFor(x => x.ImageUrl)
                .NotEmpty().When(x => x.ImageFile == null);
        }
    }

    public class Handler : IResultCommandHandler<Command, EditProductImageResponse>
    {
        private readonly IUploadFileService _uploadFileService;
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public Handler(
            IUploadFileService uploadFileService,
            IProductRepository productRepository,
            IMediator mediator,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            this._uploadFileService = uploadFileService;
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task<EditProductImageResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            var query = new GetProductRawQuery.Query(
                request.ProductId,
                request.UserId);

            var product = await this._mediator.Send(query, cancellationToken);

            if (request.ImageFile is null && !string.IsNullOrEmpty(request.ImageUrl))
            {
                var existingImage = Image.Create(request.ImageUrl);
                product.UpdateImage(existingImage);

                await this._productRepository.UpdateAsync(product);
                return new EditProductImageResponse()
                {
                    Url = request.ImageUrl,
                };
            }

            await this._uploadFileService.DeleteFileAsync(product.Image.Name);

            var image = await this._uploadFileService.UploadFileAsync(request.ImageFile, FileType.IMAGE);

            if (image is null)
            {
                throw new Exception("Failed to upload an image");
            }

            product.UpdateImage((Image)image);

            await this._productRepository.UpdateAsync(product);

            return this._mapper.Map<EditProductImageResponse>(product);
        }
    }
}
