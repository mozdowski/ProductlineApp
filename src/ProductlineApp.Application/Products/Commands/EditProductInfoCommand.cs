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

namespace ProductlineApp.Application.Products.Commands;

public class EditProductInfoCommand
{
    public record Command(
        Guid UserId,
        Guid ProductId,
        string Name,
        string Category,
        decimal Price,
        int Quantity,
        string BrandName,
        string Description,
        List<string>? Gallery,
        IFormFile? ImageFile,
        string? ImageUrl) : IResultCommand<EditProductInfoResponse>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty();
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.UserId).NotEmpty();
            this.RuleFor(x => x.ImageFile)
                .NotNull().When(x => string.IsNullOrWhiteSpace(x.ImageUrl));
            this.RuleFor(x => x.ImageUrl)
                .NotEmpty().When(x => x.ImageFile == null);
        }
    }

    public class Handler : IResultCommandHandler<Command, EditProductInfoResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public Handler(
            IProductRepository productRepository,
            IMediator mediator,
            IMapper mapper,
            IUploadFileService uploadFileService)
        {
            this._productRepository = productRepository;
            this._mediator = mediator;
            this._mapper = mapper;
            this._uploadFileService = uploadFileService;
        }

        public async Task<EditProductInfoResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            var query = new GetProductRawQuery.Query(
                request.ProductId,
                request.UserId);

            var product = await this._mediator.Send(query, cancellationToken);

            product.UpdateInfo(
                request.Name,
                request.Category,
                request.Price,
                request.Quantity,
                request.BrandName,
                request.Description);

            var updateImageCommand = new EditProductImageCommand.Command(request.UserId, request.ProductId, request.ImageFile, request.ImageUrl);
            await this._mediator.Send(updateImageCommand, cancellationToken);

            if (product.Gallery.Any())
            {
                foreach (var image in product.Gallery)
                {
                    await this._uploadFileService.DeleteFileAsync(image.Name);
                }

                product.ClearGallery();
            }

            if (request.Gallery is not null && request.Gallery.Any())
            {
                request.Gallery.ForEach(x => product.AddImageToGallery(Image.Create(x)));
            }

            await this._productRepository.UpdateAsync(product);

            return this._mapper.Map<EditProductInfoResponse>(product);
        }
    }
}
