namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroWithdrawOfferRequest
{
    public List<WithdrawOfferCriteria> OfferCriteria { get; set; }

    public WithdrawPublication Publication { get; set; }

    public class Offer
    {
        public string Id { get; set; }
    }

    public class WithdrawOfferCriteria
    {
        public List<Offer> Offers { get; set; }

        public string Type { get; set; } = "CONTAINS_OFFERS";
    }

    public class WithdrawPublication
    {
        public string Action { get; set; } = "END";
    }
}
