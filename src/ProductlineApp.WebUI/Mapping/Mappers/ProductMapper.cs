using AutoMapper;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.WebUI.DTO.Product;
using ProductlineApp.WebUI.Mapping.Resolvers;

namespace ProductlineApp.WebUI.Mapping.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        this.CreateMap<ProductDtoRequest, Product>()
            .ForMember(
                dst => dst.OwnerId,
                opt => opt.MapFrom<ProductUserIdResolver>());
    }
}
