using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Products.Commands;

public class AddCategoryCommand
{
    public record Command(
        string CategoryName,
        Guid UserId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.CategoryName).NotEmpty();
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await this._productRepository.AddCategoryAsync(
                UserId.Create(request.UserId),
                new Category(request.CategoryName));

            return Unit.Value;
        }
    }
}
