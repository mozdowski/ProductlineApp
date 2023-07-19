namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayProductDetailsResponse
{
    public string Sku { get; set; }

    public string Locale { get; set; }

    public EbayDetailedProduct Product { get; set; }

    public string Condition { get; set; }

    public EbayProductDetailsAvailability Availability { get; set; }

    public class EbayDetailedProduct
    {
        public string Title { get; set; }

        public Dictionary<string, List<string>> Aspects { get; set; }

        public string Description { get; set; }

        public List<string> ImageUrls { get; set; }
    }

    public class ShipToLocationAvailability
    {
        public int Quantity { get; set; }

        public Dictionary<string, int> AllocationByFormat { get; set; }
    }

    public class EbayProductDetailsAvailability
    {
        public ShipToLocationAvailability ShipToLocationAvailability { get; set; }
    }
}
