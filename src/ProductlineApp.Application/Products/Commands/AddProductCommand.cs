using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductlineApp.Application.Categories.Queries;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Security;
using ProductlineApp.Application.Products.Models;
using ProductlineApp.Application.Sellers.Queries;
using ProductlineApp.Domain.Entities;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Application.Products.Commands;

public class AddProductCommand
{
    public record Command(AddProductDtoRequest Request) : ICommand<Guid>;

    public class Validator : AbstractValidator<AddProductDtoRequest>
    {
        public Validator()
        {
        }
    }

    public class Handler : ICommandHandler<Command, Guid>
    {
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _context;
        private readonly IAuthorizationManager _authorizationManager;

        public Handler(
            IMediator mediator,
            IApplicationDbContext context,
            IAuthorizationManager authorizationManager)
        {
            this._mediator = mediator;
            this._context = context;
            this._authorizationManager = authorizationManager;
        }

        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var owner = await this._mediator.Send(
                new GetSellerByNicknameQuery.Query(this._authorizationManager.Identity.Name),
                cancellationToken);

            var category = await this._mediator.Send(
                new GetCategoryByIdQuery.Query(request.Request.CategoryId),
                cancellationToken);

            var newProduct = new Product(
                request.Request.ProductId,
                request.Request.Name,
                category,
                request.Request.Price,
                request.Request.Quantity,
                request.Request.Image ?? Image.EmptyImage(),
                request.Request.Brand,
                request.Request.Description,
                owner);

            await this._context.Products.AddAsync(newProduct, cancellationToken);

            return newProduct.Id;
        }
    }
}
