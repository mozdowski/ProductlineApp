using AutoMapper;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.WebUI.Mapping.Resolvers;

// public class ProductResolver : IValueResolver<ProductDtoRequest, Product, Product>
// {
//     private readonly ICurrentUserContext _currentUser;
//
//     public ProductResolver(ICurrentUserContext currentUser)
//     {
//         this._currentUser = currentUser;
//     }
//
//     public Product Resolve(ProductDtoRequest source, Product destination, Product destMember, ResolutionContext context)
//     {
//         return Product.Create(
//             source.Sku,
//             source.Name,
//             source.CategoryName,
//             source.Price,
//             source.Quantity,
//             Image.Create(source.ImageUrl),
//             source.BrandName,
//             source.Description,
//             UserId.Create(this._currentUser.UserId.Value));
//     }
// }
