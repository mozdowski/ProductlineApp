namespace ProductlineApp.Shared.Models.Ebay;

public class EbayInventoryItems
{
    public string Href { get; set; }

    public List<InventoryItem> InventoryItems { get; set; }

    public int Limit { get; set; }

    public string? Next { get; set; }

    public string Prev { get; set; }

    public int Size { get; set; }

    public int Total { get; set; }

    public class PickupAtLocationAvailability
    {
        public string AvailabilityType { get; set; }

        public FulfillmentTime FulfillmentTime { get; set; }

        public string MerchantLocationKey { get; set; }

        public int Quantity { get; set; }
    }

    public class ShipToLocationAvailability
    {
        public AllocationByFormat AllocationByFormat { get; set; }

        public List<AvailabilityDistribution> AvailabilityDistributions { get; set; }

        public int Quantity { get; set; }
    }

    public class Availability
    {
        public List<PickupAtLocationAvailability> PickupAtLocationAvailability { get; set; }

        public ShipToLocationAvailability ShipToLocationAvailability { get; set; }
    }

    public class FulfillmentTime
    {
        public string Unit { get; set; }

        public int Value { get; set; }
    }

    public class AllocationByFormat
    {
        public int Auction { get; set; }

        public int FixedPrice { get; set; }
    }

    public class AvailabilityDistribution
    {
        public FulfillmentTime FulfillmentTime { get; set; }

        public string MerchantLocationKey { get; set; }

        public int Quantity { get; set; }
    }

    public class Dimensions
    {
        public double Height { get; set; }

        public double Length { get; set; }

        public string Unit { get; set; }

        public double Width { get; set; }
    }

    public class Weight
    {
        public string Unit { get; set; }

        public double Value { get; set; }
    }

    public class PackageWeightAndSize
    {
        public Dimensions Dimensions { get; set; }

        public string PackageType { get; set; }

        public Weight Weight { get; set; }
    }

    public class EbayInventoryProduct
    {
        public string Aspects { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public List<string> Ean { get; set; }

        public string Epid { get; set; }

        public List<string> ImageUrls { get; set; }

        public List<string> Isbn { get; set; }

        public string Mpn { get; set; }

        public string Subtitle { get; set; }

        public string Title { get; set; }

        public List<string> Upc { get; set; }

        public List<string> VideoIds { get; set; }
    }

    public class InventoryItem
    {
        public Availability Availability { get; set; }

        public string Condition { get; set; }

        public string ConditionDescription { get; set; }

        public List<string> GroupIds { get; set; }

        public List<string> InventoryItemGroupKeys { get; set; }

        public string Locale { get; set; }

        public PackageWeightAndSize PackageWeightAndSize { get; set; }

        public EbayInventoryProduct Product { get; set; }

        public string Sku { get; set; }
    }
}
