namespace ProductlineApp.Shared.Models.Ebay;

public class EbayLocationsResponse
{
    public string Href { get; set; }

    public int Limit { get; set; }

    public string? Next { get; set; }

    public int Offset { get; set; }

    public string? Prev { get; set; }

    public int Total { get; set; }

    public List<LocationItem> Locations { get; set; }

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

    public class OperatingHourInterval
    {
        public string Close { get; set; }

        public string Open { get; set; }
    }

    public class OperatingHour
    {
        public string DayOfWeekEnum { get; set; }

        public List<OperatingHourInterval> Intervals { get; set; }
    }

    public class SpecialHourInterval
    {
        public string Close { get; set; }

        public string Open { get; set; }
    }

    public class SpecialHour
    {
        public string Date { get; set; }

        public List<SpecialHourInterval> Intervals { get; set; }
    }

    public class LocationItem
    {
        public Location Location { get; set; }

        public string LocationAdditionalInformation { get; set; }

        public string LocationInstructions { get; set; }

        public List<string> LocationTypes { get; set; }

        public string LocationWebUrl { get; set; }

        public string MerchantLocationKey { get; set; }

        public string MerchantLocationStatus { get; set; }

        public string Name { get; set; }

        public List<OperatingHour> OperatingHours { get; set; }

        public string Phone { get; set; }

        public List<SpecialHour> SpecialHours { get; set; }
    }
}
