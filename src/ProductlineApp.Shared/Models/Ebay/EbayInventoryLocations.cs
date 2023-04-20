namespace ProductlineApp.Shared.Models.Ebay;

public class EbayInventoryLocations
{
    public string Href { get; set; }

    public int Limit { get; set; }

    public string Next { get; set; }

    public int Offset { get; set; }

    public string Prev { get; set; }

    public int Total { get; set; }

    public List<LocationInfo> Locations { get; set; }

    public class Address
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string PostalCode { get; set; }

        public string StateOrProvince { get; set; }
    }

    public class GeoCoordinates
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }

    public class Location
    {
        public Address Address { get; set; }

        public GeoCoordinates GeoCoordinates { get; set; }

        public string LocationId { get; set; }
    }

    public class OperatingHoursInterval
    {
        public string Close { get; set; }

        public string Open { get; set; }
    }

    public class OperatingHours
    {
        public string DayOfWeekEnum { get; set; }

        public List<OperatingHoursInterval> Intervals { get; set; }
    }

    public class SpecialHoursInterval
    {
        public string Close { get; set; }

        public string Open { get; set; }
    }

    public class SpecialHours
    {
        public string Date { get; set; }

        public List<SpecialHoursInterval> Intervals { get; set; }
    }

    public class LocationInfo
    {
        public Location Location { get; set; }

        public string LocationAdditionalInformation { get; set; }

        public string LocationInstructions { get; set; }

        public List<string> LocationTypes { get; set; }

        public string LocationWebUrl { get; set; }

        public string MerchantLocationKey { get; set; }

        public string MerchantLocationStatus { get; set; }

        public string Name { get; set; }

        public List<OperatingHours> OperatingHours { get; set; }

        public string Phone { get; set; }

        public List<SpecialHours> SpecialHours { get; set; }
    }
}
