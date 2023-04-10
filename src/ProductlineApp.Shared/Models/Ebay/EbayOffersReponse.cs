namespace ProductlineApp.Shared.Models.Ebay;

public class EbayOffersReponse
{
    public string Href { get; set; }

    public int Limit { get; set; }

    public string Next { get; set; }

    public List<Offer> Offers { get; set; }

    public string Prev { get; set; }

    public int Size { get; set; }

    public int Total { get; set; }

    public class Offer
        {
        public int AvailableQuantity { get; set; }

        public string CategoryId { get; set; }

        public Charity Charity { get; set; }

        public ExtendedProducerResponsibility ExtendedProducerResponsibility { get; set; }

        public string Format { get; set; }

        public bool HideBuyerDetails { get; set; }

        public bool IncludeCatalogProductDetails { get; set; }

        public Listing Listing { get; set; }

        public string ListingDescription { get; set; }

        public string ListingDuration { get; set; }

        public ListingPolicies ListingPolicies { get; set; }

        public string ListingStartDate { get; set; }

        public int LotSize { get; set; }

        public string MarketplaceId { get; set; }

        public string MerchantLocationKey { get; set; }

        public string OfferId { get; set; }

        public PricingSummary PricingSummary { get; set; }

        public int QuantityLimitPerBuyer { get; set; }

        public Regulatory Regulatory { get; set; }

        public string SecondaryCategoryId { get; set; }

        public string Sku { get; set; }

        public string Status { get; set; }

        public List<string> StoreCategoryNames { get; set; }

        public Tax Tax { get; set; }
    }

    public class Charity
    {
        public string CharityId { get; set; }

        public string DonationPercentage { get; set; }
    }

    public class EcoParticipationFee
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class ExtendedProducerResponsibility
    {
        public EcoParticipationFee EcoParticipationFee { get; set; }

        public string ProducerProductId { get; set; }

        public string ProductDocumentationId { get; set; }

        public string ProductPackageId { get; set; }

        public string ShipmentPackageId { get; set; }
    }

    public class AutoAcceptPrice
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class AutoDeclinePrice
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class BestOfferTerms
    {
        public AutoAcceptPrice AutoAcceptPrice { get; set; }

        public AutoDeclinePrice AutoDeclinePrice { get; set; }

        public bool BestOfferEnabled { get; set; }
    }

    public class AdditionalShippingCost
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class ShippingCost
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class Surcharge
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class ShippingCostOverride
    {
        public AdditionalShippingCost AdditionalShippingCost { get; set; }

        public int Priority { get; set; }

        public ShippingCost ShippingCost { get; set; }

        public string ShippingServiceType { get; set; }

        public Surcharge Surcharge { get; set; }
    }

    public class ListingPolicies
    {
        public BestOfferTerms BestOfferTerms { get; set; }

        public bool EbayPlusIfEligible { get; set; }

        public string FulfillmentPolicyId { get; set; }

        public string PaymentPolicyId { get; set; }

        public List<string> ProductCompliancePolicyIds { get; set; }

        public string ReturnPolicyId { get; set; }

        public List<ShippingCostOverride> ShippingCostOverrides { get; set; }

        public string TakeBackPolicyId { get; set; }
    }

    public class AuctionReservePrice
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class AuctionStartPrice
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class MinimumAdvertisedPrice
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class OriginalRetailPrice
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class Price
    {
        public string Currency { get; set; }

        public string Value { get; set; }
    }

    public class PricingSummary
    {
        public AuctionReservePrice AuctionReservePrice { get; set; }

        public AuctionStartPrice AuctionStartPrice { get; set; }

        public string ConvertedFromCurrency { get; set; }

        public MinimumAdvertisedPrice MinimumAdvertisedPrice { get; set; }

        public OriginalRetailPrice OriginalRetailPrice { get; set; }

        public Price Price { get; set; }
    }

    public class Tax
    {
        public string JurisdictionId { get; set; }

        public string Percentage { get; set; }

        public string TaxDescription { get; set; }

        public string TaxName { get; set; }

        public string TaxOnHandlingAmount { get; set; }

        public string TaxOnShippingAmount { get; set; }

        public string TaxOnSubtotalAmount { get; set; }

        public string TotalTaxAmount { get; set; }
    }

    public class ShippingOption
    {
        public string ExpeditedService { get; set; }

        public string ShippingCarrierCode { get; set; }

        public string ShippingCarrierName { get; set; }

        public string ShippingServiceCode { get; set; }

        public string ShippingServiceName { get; set; }
    }

    public class ShippingOptionWithCost
    {
        public string ExpeditedService { get; set; }

        public string ShippingCarrierCode { get; set; }

        public string ShippingCarrierName { get; set; }

        public string ShippingServiceCode { get; set; }

        public string ShippingServiceName { get; set; }

        public string ShippingServiceCost { get; set; }
    }

    public class ShippingSurcharge
    {
        public string Currency { get; set; }

        public string MaxAmount { get; set; }

        public string SurchargeType { get; set; }

        public string Value { get; set; }
    }

    public class ShipToLocation
    {
        public string Country { get; set; }

        public string PostalCode { get; set; }
    }

    public class Listing
    {
        public bool BestOfferEnabled { get; set; }

        public string Description { get; set; }

        public string EbayCollectAndRemitTax { get; set; }

        public bool EbayCollectAndRemitTaxInclusive { get; set; }

        public string EbayCollectAndRemitTaxType { get; set; }

        public bool EbayPlusEnabled { get; set; }

        public string EbayPlusLevel { get; set; }

        public string EbayPlusRelistEnabled { get; set; }

        public string EbayPlusShippingCost { get; set; }

        public string EbayPlusSubTitle { get; set; }

        public string EbayPlusTier { get; set; }

        public string EbayPlusTitle { get; set; }

        public string EbayPlusTotalShippingCost { get; set; }

        public string EbayPlusVATEnabled { get; set; }

        public string ItemEndDate { get; set; }

        public string ItemId { get; set; }

        public string ItemLocation { get; set; }

        public string ItemStartDate { get; set; }

        public List<ShippingOption> ShippingOptions { get; set; }

        public List<ShippingOptionWithCost> ShippingOptionsWithCost { get; set; }

        public ShippingSurcharge ShippingSurcharge { get; set; }

        public string TimeLeft { get; set; }

        public string Title { get; set; }

        public string TopRatedListing { get; set; }

        public string ViewItemURL { get; set; }
    }

    public class Regulatory
    {
        public bool Ean { get; set; }

        public bool Restrictions { get; set; }

        public bool Text { get; set; }

        public bool Warning { get; set; }
    }
}
