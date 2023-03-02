using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Products.Models;

namespace ProductlineApp.Application.Products.Queries;

public class GetProductsByUserIdQuery
{
    public record Query(Guid UserId) : IQuery<ProductListModel>;

    public class Validator : AbstractValidator<ProductListModel>
    {
        public Validator()
        {
        }
    }

    public class Handler : IQueryHandler<Query, ProductListModel>
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

        public async Task<ProductListModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var products = await this._context.Sellers
                .Where(x => x.Id == request.UserId)
                .Select(x => x.Products)
                .ToListAsync(cancellationToken);

            return this._mapper.Map<ProductListModel>(products);
        }
    }
}
