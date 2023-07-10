namespace ProductlineApp.Shared.Models.Allegro;

public class ShippingRatesResponse
{
    public IEnumerable<ShippingRate> ShippingRates { get; set; }

    public class ShippingRate
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
