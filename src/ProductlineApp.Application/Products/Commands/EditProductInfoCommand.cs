using AutoMapper;
using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Application.Products.Queries;
using ProductlineApp.Domain.Aggregates.Products.Repository;

namespace ProductlineApp.Application.Products.Commands;

public class EditProductInfoCommand
{
    public record Command(
        Guid ProductId,
        string Name,
        string? Category,
        decimal Price,
        int Quantity,
        string BrandName,
        string Description,
        Guid UserId) : IResultCommand<EditProductInfoResponse>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty();
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : IResultCommandHandler<Command, EditProductInfoResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public Handler(
            IProductRepository productRepository,
            IMediator mediator,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mediator = mediator;
            this._mapper = mapper;
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

            await this._productRepository.UpdateAsync(product);

            return this._mapper.Map<EditProductInfoResponse>(product);
        }
    }
}
