using AutoMapper;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.WebUI.Mapping.Mappers;

// public class ProductMapper : Profile
// {
//     public ProductMapper(ICurrentUserContext currentUser)
//     {
//         this.CreateMap<ProductDtoRequest, Product>().ConstructUsing(source =>
//             Product.Create(
//                 source.Sku,
//                 source.Name,
//                 source.CategoryName,
//                 source.Price,
//                 source.Quantity,
//                 Image.Create(source.ImageUrl),
//                 source.BrandName,
//                 source.Description,
//                 UserId.Create(currentUser.UserId.Value)));
//     }
// }
