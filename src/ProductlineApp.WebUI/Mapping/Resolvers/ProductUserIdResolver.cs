using System.Security.Claims;
using AutoMapper;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.WebUI.DTO.Product;

namespace ProductlineApp.WebUI.Mapping.Resolvers;

public class ProductUserIdResolver : IValueResolver<ProductDtoRequest, Product, UserId>
{
    private readonly ICurrentUserContext _currentUser;

    public ProductUserIdResolver(ICurrentUserContext currentUser)
    {
        this._currentUser = currentUser;
    }

    public UserId Resolve(ProductDtoRequest source, Product destination, UserId destMember, ResolutionContext context)
    {
        var userId = this._currentUser.UserId;
        return UserId.Create(userId.Value);
    }
}
