using AutoMapper;
using ProductlineApp.Application.Product.DTO;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;

namespace ProductlineApp.Application.Common.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        this.CreateMap<IEnumerable<Domain.Aggregates.Product.Product>, IEnumerable<ProductDto>>();
        this.CreateMap<Domain.Aggregates.Product.Product, ProductDto>();
        this.CreateMap<List<Category>, List<string>>();
        this.CreateMap<Category, string>();
    }
}
