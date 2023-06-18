using AutoMapper;
using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Shared.Models.Common;
using ProductlineApp.Shared.Models.Ebay;
using System.Globalization;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Mappings;

public class EbayMapper : Profile
{
    public EbayMapper()
    {
        this.CreateMap<EbayOfferDtoRequest, EbayCreateOfferRequest>();

        this.CreateMap<EbayCreateOfferMapperInput, EbayCreateOfferRequest>()
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(x => x.EbayItemSku))
            .ForMember(dest => dest.MarketplaceId, opt => opt.MapFrom(x => x.OfferDetails.MarketplaceId))
            .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.OfferDetails.Quantity))
            .ForMember(
                dest => dest.QuantityLimitPerBuyer,
                opt => opt.MapFrom(src => src.OfferDetails.QuantityLimitPerBuyer ?? 0))
            .ForMember(
                dest => dest.PricingSummary,
                opt => opt.MapFrom(src => new EbayCreateOfferRequest.PricingSummaryObject
                {
                    Price = new EbayCreateOfferRequest.Price
                        {
                            Value = src.OfferDetails.Price,
                            Currency = "PLN",
                        },
                }))
            .ForMember(
                dest => dest.ListingPolicies,
                opt => opt.MapFrom(src => new EbayCreateOfferRequest.ListingPoliciesObject
                {
                    FulfillmentPolicyId = src.OfferDetails.FulfillmentPolicyId,
                    PaymentPolicyId = src.OfferDetails.PaymentPolicyId, ReturnPolicyId = src.OfferDetails.ReturnPolicyId,
                }))
            .ForMember(dest => dest.Format, opt => opt.MapFrom(x => x.OfferDetails.Format))
            .ForMember(dest => dest.ListingDescription, opt => opt.MapFrom(x => x.OfferDetails.ListingDescription))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(x => x.OfferDetails.CategoryId))
            .ForMember(dest => dest.MerchantLocationKey, opt => opt.MapFrom(x => x.OfferDetails.LocationKey))
            .ForMember(dest => dest.Tax, opt => opt.Ignore());

        // .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => new EbayCreateOfferRequest.TaxObject { VatPercentage = 0, ApplyTax = false, ThirdPartyTaxCategory = "" }));

        this.CreateMap<EbayOffersReponse.Offer, ListingDtoResponse>()
            .ForMember(x => x.Title, opt => opt.Ignore())
            .ForMember(x => x.Price, opt => opt.MapFrom(x => decimal.Parse(x.PricingSummary.Price.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture)))
            .ForMember(x => x.Quantity, opt => opt.MapFrom(x => x.AvailableQuantity))
            .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.OfferId))
            .ForMember(x => x.Description, opt => opt.MapFrom(x => x.ListingDescription))
            .ForMember(x => x.PlatformListingUrl, opt => opt.Ignore())
            .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.Status == "PUBLISHED" && x.Listing.ListingStatus == "ACTIVE"))
            .ForMember(x => x.Sku, opt => opt.MapFrom(x => x.Sku))
            .ForMember(x => x.Category, opt => opt.MapFrom(x => x.CategoryName))
            .ForMember(x => x.DaysToExpire, opt => opt.Ignore())
            .ForMember(x => x.ProductId, opt => opt.Ignore())
            .ForMember(x => x.ProductName, opt => opt.Ignore())
            .ForMember(x => x.ProductImageUrl, opt => opt.Ignore());

        // this.CreateMap<Product, ListingDtoResponse>()
        //     .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Name))
        //     .ForMember(x => x.Price, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.Quantity, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.ListingId, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.Description, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.PlatformListingUrl, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.IsActive, opt => opt.DoNotUseDestinationValue())
        //     .ForMember(x => x.Sku, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.Category, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.DaysToExpire, opt => opt.UseDestinationValue())
        //     .ForMember(x => x.ProductId, opt => opt.MapFrom(x => x.Id.Value))
        //     .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Name))
        //     .ForMember(x => x.ProductImage, opt => opt.MapFrom(x => x.Image));

        this.CreateMap<EbaySuggestedCategoriesResponse, PlatformCategoriesListDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.CategorySuggestions.Select(cs => cs.Category)));

        this.CreateMap<EbaySuggestedCategoriesResponse.Category, PlatformCategory>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.CategoryId))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.CategoryName));

        this.CreateMap<EbayAspectsResponse, PlatformAspectsDtoResponse>()
            .ForMember(dest => dest.PlatformAspects, opt => opt.MapFrom(src => src.Aspects));

        this.CreateMap<EbayAspectsResponse.Aspect, PlatformAspectResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocalizedAspectName))
            .ForMember(dest => dest.DataType, opt => opt.MapFrom(src => src.AspectConstraint.AspectDataType))
            .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.AspectConstraint.AspectRequired))
            .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.AspectValues == null ? null : src.AspectValues.Select(v => v.LocalizedValue)));

        this.CreateMap<EbayCategoryTreeResponse, EbayCategoryTreeDto>();

        this.CreateMap<EbayOrderResponse, OrderDtoResponse>()
            .ForMember(
                dest => dest.MaxDeliveryDate,
                opt => opt.MapFrom(src => src.FulfillmentStartInstructions[0].MaxEstimatedDeliveryDate))
            .ForMember(
                dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Buyer.BuyerRegistrationAddress.FullName))
            .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Buyer.BuyerRegistrationAddress.Email))
            .ForMember(
                dest => dest.CustomerPhoneNumber,
                opt => opt.MapFrom(src => src.Buyer.BuyerRegistrationAddress.PrimaryPhone.PhoneNumber))
            .ForMember(dest => dest.CustomerAddress,
                opt => opt.MapFrom(src => src.Buyer.BuyerRegistrationAddress.ContactAddress))
            .ForMember(dest => dest.ShippingAddress,
                opt => opt.MapFrom(src => src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.ContactAddress))
            .ForMember(dest => dest.TotalPrice,
                opt => opt.MapFrom(src => decimal.Parse(src.PricingSummary.Total.Value)))
            .ForMember(dest => dest.SubtotalPrice,
                opt => opt.MapFrom(src => decimal.Parse(src.PricingSummary.PriceSubtotal.Value)))
            .ForMember(dest => dest.DeliveryCost,
                opt => opt.MapFrom(src => decimal.Parse(src.PricingSummary.DeliveryCost.ShippingCost.Value)))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.LineItems[0].Quantity))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderFulfillmentStatus))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.LineItems));

        this.CreateMap<EbayOrderResponse.LineItem, OrderItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => decimal.Parse(src.LineItemCost.Value)))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.DeliveryCost, opt => opt.MapFrom(src => decimal.Parse(src.DeliveryCost.ShippingCost.Value)))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => decimal.Parse(src.Total.Value)))
            .ForMember(dest => dest.FulfillmentStatus, opt => opt.MapFrom(src => src.LineItemFulfillmentStatus));

        this.CreateMap<EbayLocationsResponse.LocationItem, EbayLocationsDtoResponse.EbayLocationDto>()
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.MerchantLocationKey))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => GetFormattedAddress(src.Location.Address)));
    }

    private static string GetFormattedAddress(EbayLocationsResponse.Address address)
    {
        return $"{address.AddressLine1}, {address.City}, {address.StateOrProvince}, {address.PostalCode}, {address.Country}";
    }
}
