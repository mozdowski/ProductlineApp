﻿using AutoMapper;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;

namespace ProductlineApp.Application.Common.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        // this.CreateMap<IEnumerable<Domain.Aggregates.Products.Product>, IEnumerable<ProductDto>>();
        // this.CreateMap<Domain.Aggregates.Products.Product, ProductDto>();
        // this.CreateMap<List<Category>, List<string>>();
        // this.CreateMap<Category, string>();
    }
}
