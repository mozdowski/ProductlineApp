using AutoMapper;
using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Mappings;

public class EbayServiceMapper : Profile
{
    public EbayServiceMapper()
    {
        this.CreateMap<EbayInventoryItemDto, EbayCreateOrReplaceInventoryRequest>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => new EbayCreateOrReplaceInventoryRequest.EbayProduct
            {
                Title = src.Title,
                Aspects = src.Aspects,
                Description = src.Description,
                Upc = null,
                ImageUrls = src.ImageUrls.ToList(),
            }))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition))
            .ForMember(dest => dest.PackageWeightAndSize, opt => opt.Ignore())
            .ForMember(dest => dest.Availability, opt => opt.MapFrom(src => new EbayCreateOrReplaceInventoryRequest.AvailabilityObject
            {
                ShipToLocationAvailability = new EbayCreateOrReplaceInventoryRequest.ShipToLocationAvailability
                {
                    Quantity = src.Quantity,
                },
            }));

        this.CreateMap<Product, EbayCreateOrReplaceInventoryRequest>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => new EbayCreateOrReplaceInventoryRequest.EbayProduct
            {
                Title = src.Name,
                Description = src.Description,
                ImageUrls = src.Gallery.Select(i => i.Url.ToString()).ToList(),
            }))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => "NEW"))
            .ForMember(dest => dest.Availability, opt => opt.MapFrom(src => new EbayCreateOrReplaceInventoryRequest.AvailabilityObject
            {
                ShipToLocationAvailability = new EbayCreateOrReplaceInventoryRequest.ShipToLocationAvailability
                {
                    Quantity = src.Quantity,
                },
            }));
    }
}
