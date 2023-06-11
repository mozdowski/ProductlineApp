namespace ProductlineApp.Shared.Models.Ebay;

public class EbayCreateOrReplaceInventoryRequest
{
    public EbayProduct Product { get; set; }

    public string Condition { get; set; }

    public PackageWeightAndSizeObject? PackageWeightAndSize { get; set; }

    public AvailabilityObject Availability { get; set; }

    public class EbayProduct
    {
        public string Title { get; set; }

        public IDictionary<string, IEnumerable<string>>? Aspects { get; set; }

        public string Description { get; set; }

        public List<string>? Upc { get; set; }

        public List<string> ImageUrls { get; set; }
    }

    public class PackageWeightAndSizeObject
    {
        public DimensionsObject Dimensions { get; set; }

        public string PackageType { get; set; }

        public Weight Weight { get; set; }
    }

    public class DimensionsObject
    {
        public int Height { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public string Unit { get; set; }
    }

    public class Weight
    {
        public int Value { get; set; }

        public string Unit { get; set; }
    }

    public class AvailabilityObject
    {
        public ShipToLocationAvailability ShipToLocationAvailability { get; set; }
    }

    public class ShipToLocationAvailability
    {
        public int Quantity { get; set; }
    }
}
