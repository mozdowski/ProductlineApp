using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Product.DTO;
using ProductlineApp.Domain.Aggregates.Product.Repository;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using System.Security.Authentication;
using MediatR;

namespace ProductlineApp.Application.Product.Queries;

public class GetProductByIdQuery
{
    public record Query(
        Guid ProductId,
        Guid UserId) : IQuery<GetProductResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty();
            this.RuleFor(x => x.UserId).NotEmpty();
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

            return new GetProductResponse(
                this._mapper.Map<ProductDto>(product));
        }
    }
}
