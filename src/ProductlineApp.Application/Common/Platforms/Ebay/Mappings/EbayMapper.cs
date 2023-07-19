using AutoMapper;
using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Enums;
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
            .ForMember(x => x.PlatformListingId, opt => opt.MapFrom(x => x.OfferId))
            .ForMember(x => x.ListingInstanceId, opt => opt.Ignore())
            .ForMember(x => x.ListingId, opt => opt.Ignore())
            .ForMember(x => x.Description, opt => opt.MapFrom(x => x.ListingDescription))
            .ForMember(x => x.PlatformListingUrl, opt => opt.Ignore())
            .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.Status == "PUBLISHED" && x.Listing.ListingStatus == "ACTIVE"))
            .ForMember(x => x.Sku, opt => opt.MapFrom(x => x.Sku))
            .ForMember(x => x.Category, opt => opt.MapFrom(x => x.CategoryName))
            .ForMember(x => x.DaysToExpire, opt => opt.Ignore())
            .ForMember(x => x.ProductId, opt => opt.Ignore())
            .ForMember(x => x.ProductName, opt => opt.Ignore())
            .ForMember(x => x.ProductImageUrl, opt => opt.Ignore());

        this.CreateMap<EbayOfferDtoRequest, EbayUpdateOfferRequest>()
            .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(
                dest => dest.QuantityLimitPerBuyer,
                opt => opt.MapFrom(src => src.QuantityLimitPerBuyer ?? 0))
            .ForMember(
                dest => dest.PricingSummary,
                opt => opt.MapFrom(src => new EbayUpdateOfferRequest.PricingSummaryObject
                {
                    Price = new EbayUpdateOfferRequest.Price
                    {
                        Value = src.Price,
                        Currency = "PLN",
                    },
                }))
            .ForMember(
                dest => dest.ListingPolicies,
                opt => opt.MapFrom(src => new EbayUpdateOfferRequest.ListingPoliciesObject
                {
                    FulfillmentPolicyId = src.FulfillmentPolicyId,
                    PaymentPolicyId = src.PaymentPolicyId,
                    ReturnPolicyId = src.ReturnPolicyId,
                }))
            .ForMember(dest => dest.ListingDescription, opt => opt.MapFrom(x => x.ListingDescription))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(x => x.CategoryId))
            .ForMember(dest => dest.MerchantLocationKey, opt => opt.MapFrom(x => x.LocationKey));

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
            .ForMember(dest => dest.Values,
                opt => opt.MapFrom(src =>
                    src.AspectValues == null ? null : src.AspectValues.Select(v => v.LocalizedValue)))
            .ForMember(dest => dest.Mode, opt => opt.MapFrom(src => src.AspectConstraint.AspectMode))
            .ForMember(dest => dest.IsSingleValue, opt => opt.MapFrom(src => src.AspectConstraint.ItemToAspectCardinality == "SINGLE"));

        this.CreateMap<EbayCategoryTreeResponse, EbayCategoryTreeDto>();

        this.CreateMap<EbayOrderResponse, OrderDtoResponse>()
            .ForMember(
                dest => dest.MaxDeliveryDate,
                opt => opt.MapFrom(src => src.FulfillmentStartInstructions[0].MaxEstimatedDeliveryDate))
            .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => new BillingAddress()
            {
                FirstName = src.Buyer.BuyerRegistrationAddress.FullName,
                Username = src.Buyer.Username,
                Email = src.Buyer.BuyerRegistrationAddress.Email,
                PhoneNumber = src.Buyer.BuyerRegistrationAddress.PrimaryPhone.PhoneNumber,
                Address = new Address(src.Buyer.BuyerRegistrationAddress.ContactAddress.AddressLine1 + " " + src.Buyer.BuyerRegistrationAddress.ContactAddress.AddressLine2, src.Buyer.BuyerRegistrationAddress.ContactAddress.PostalCode, src.Buyer.BuyerRegistrationAddress.ContactAddress.City, src.Buyer.BuyerRegistrationAddress.ContactAddress.CountryCode),
            }))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => new ShippingAddress()
            {
                FirstName = src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.FullName,
                PhoneNumber = src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.PrimaryPhone.PhoneNumber,
                Address = new Address(src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.ContactAddress.AddressLine1 + " " + src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.ContactAddress.AddressLine2, src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.ContactAddress.PostalCode, src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.ContactAddress.City, src.FulfillmentStartInstructions[0].ShippingStep.ShipTo.ContactAddress.CountryCode),
            }))
            .ForMember(dest => dest.TotalPrice,
                opt => opt.MapFrom(src => decimal.Parse(src.PricingSummary.Total.Value)))
            .ForMember(dest => dest.SubtotalPrice,
                opt => opt.MapFrom(src => decimal.Parse(src.PricingSummary.PriceSubtotal.Value)))
            .ForMember(dest => dest.DeliveryCost,
                opt => opt.MapFrom(src => decimal.Parse(src.PricingSummary.DeliveryCost.ShippingCost.Value)))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.LineItems[0].Quantity))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderFulfillmentStatus))
            .ForMember(dest => dest.Platform, opt => opt.MapFrom(src => PlatformNames.EBAY))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.LineItems));

        this.CreateMap<EbayOrderResponse.LineItem, OrderItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => decimal.Parse(src.LineItemCost.Value)))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.DeliveryCost, opt => opt.MapFrom(src => decimal.Parse(src.DeliveryCost.ShippingCost.Value)))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => decimal.Parse(src.Total.Value)))
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
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
