using AutoMapper;
using ProductlineApp.Application.Products.Models;
using ProductlineApp.Domain.Entities;

namespace ProductlineApp.Application.Common.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        this.CreateMap<IEnumerable<Product>, ProductListModel>();
        this.CreateMap<Product, ProductDtoResponse>();
    }
}
