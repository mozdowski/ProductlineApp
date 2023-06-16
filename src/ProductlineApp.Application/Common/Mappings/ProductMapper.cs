using AutoMapper;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Common.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        // this.CreateMap<ProductResponseMapperInput, ProductDtoResponse>();

        this.CreateMap<ProductResponseMapperInput, ProductDtoResponse>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.Image.Url))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Product.Brand.Name))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Product.Condition))
            .ForMember(dest => dest.Platforms, opt => opt.MapFrom(src => src.Platforms))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Product.Category.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Product.Quantity))
            .ForMember(dest => dest.Gallery, opt => opt.MapFrom(src => GetGalleryUrls(src.Product)));

        this.CreateMap<string, PlatformNames>()
            .ConvertUsing(src => Enum.Parse<PlatformNames>(src.ToUpper()));

        // this.CreateMap<Product, ProductDtoResponse>()
        //     .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image.Url.ToString()))
        //     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
        //     .ForMember(dest => dest.Gallery, opt => opt.MapFrom(src => GetGalleryUrls(src)));

        this.CreateMap<Product, EditProductInfoResponse>();
        this.CreateMap<Product, EditProductImageResponse>()
            .ForMember(x => x.Url, opt => opt.MapFrom(src => src.Image.Url));
    }

    private static List<string> GetGalleryUrls(Product product)
    {
        return product.Gallery.Select(image => image.Url.ToString()).ToList();
    }
}
