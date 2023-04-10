using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Product.DTO;
using ProductlineApp.Domain.Aggregates.Product.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Product.Queries;

public class GetCategoriesByUserQuery
{
    public record Query(Guid UserId) : IQuery<GetCategoriesResponse>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : IQueryHandler<Query, GetCategoriesResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public Handler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        public async Task<GetCategoriesResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var categories = await this._productRepository.GetCategoriesAsync(UserId.Create(request.UserId));
            return new GetCategoriesResponse(this._mapper.Map<List<string>>(categories));
        }
    }
}
