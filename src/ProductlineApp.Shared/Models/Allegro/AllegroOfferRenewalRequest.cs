namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroOfferRenewalRequest
{
    public List<RenewalOfferCriteria> OfferCriteria { get; set; }

    public RenewalPublication Publication { get; set; }

    public class Offer
    {
        public string Id { get; set; }
    }

    public class RenewalOfferCriteria
    {
        public List<Offer> Offers { get; set; }

        public string Type { get; set; } = "CONTAINS_OFFERS";
    }

    public class RenewalPublication
    {
        public string Action { get; set; } = "ACTIVATE";
    }
}
