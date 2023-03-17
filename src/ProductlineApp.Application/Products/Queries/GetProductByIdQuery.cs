using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Products.Models;

namespace ProductlineApp.Application.Products.Queries;
public class GetProductByIdQuery
{
    public record Query(Guid UserId, Guid ProductId) : IQuery<ProductDtoResponse>;

    public class Validator : AbstractValidator<ProductDtoResponse>
    {
        public Validator()
        {
        }
    }

    public class Handler : IQueryHandler<Query, ProductDtoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Handler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ProductDtoResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var seller = await this._context.Sellers
                .FirstAsync(x => x.Id == request.UserId, cancellationToken);

            var product = seller.Products
                .FirstOrDefault(x => x.Id == request.ProductId);

            return this._mapper.Map<ProductDtoResponse>(product);
        }
    }
}
