using AutoMapper;
using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Products.DTO;

namespace ProductlineApp.Application.Products.Queries;

public class GetProductByIdQuery
{
    public record Query(
        Guid ProductId,
        Guid UserId) : IQuery<GetProductResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IQueryHandler<Query, GetProductResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public Handler(
            IMediator mediator,
            IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task<GetProductResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = new GetProductRawQuery.Query(
                request.ProductId,
                request.UserId);

            var product = await this._mediator.Send(query, cancellationToken);

            return new GetProductResponse(this._mapper.Map<ProductDtoResponse>(product));
        }
    }
}
