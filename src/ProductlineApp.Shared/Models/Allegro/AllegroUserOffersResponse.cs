namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroUserOffersResponse
{
    public List<Offer> Offers { get; set; }

    public int Count { get; set; }

    public int TotalCount { get; set; }

    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class PrimaryImage
    {
        public string Url { get; set; }
    }

    public class Price
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }

    public class SellingMode
    {
        public string Format { get; set; }

        public Price Price { get; set; }

        public Price MinimalPrice { get; set; }

        public Price StartingPrice { get; set; }
    }

    public class CurrentPrice
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }

    public class SaleInfo
    {
        public CurrentPrice CurrentPrice { get; set; }

        public int BiddersCount { get; set; }
    }

    public class Stock
    {
        public int Available { get; set; }

        public int Sold { get; set; }
    }

    public class Stats
    {
        public int WatchersCount { get; set; }

        public int VisitsCount { get; set; }
    }

    public class Publication
    {
        public string Status { get; set; }

        public DateTime? StartingAt { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? EndingAt { get; set; }

        public DateTime? EndedAt { get; set; }
    }

    public class ImpliedWarranty
    {
        public string Id { get; set; }
    }

    public class ReturnPolicy
    {
        public string Id { get; set; }
    }

    public class Warranty
    {
        public string Id { get; set; }
    }

    public class AfterSalesServices
    {
        public ImpliedWarranty ImpliedWarranty { get; set; }

        public ReturnPolicy ReturnPolicy { get; set; }

        public Warranty Warranty { get; set; }
    }

    public class AdditionalServices
    {
        public string Id { get; set; }
    }

    public class ShippingRates
    {
        public string Id { get; set; }
    }

    public class Delivery
    {
        public ShippingRates ShippingRates { get; set; }
    }

    public class B2B
    {
        public bool BuyableOnlyByBusiness { get; set; }
    }

    public class FundraisingCampaign
    {
        public string Id { get; set; }
    }

    public class Offer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }

        public PrimaryImage PrimaryImage { get; set; }

        public SellingMode SellingMode { get; set; }

        public SaleInfo SaleInfo { get; set; }

        public Stock Stock { get; set; }

        public Stats Stats { get; set; }

        public Publication Publication { get; set; }

        public AfterSalesServices AfterSalesServices { get; set; }

        public AdditionalServices AdditionalServices { get; set; }

        public External External { get; set; }

        public Delivery Delivery { get; set; }

        public B2B B2B { get; set; }

        public FundraisingCampaign FundraisingCampaign { get; set; }
    }

    public class External
    {
        public string? Id { get; set; }
    }
}
