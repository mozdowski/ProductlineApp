namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroUpdateOfferRequest
{
    public IEnumerable<ProductSet> ProductSet { get; set; }

    public B2b B2b { get; set; }

    public IEnumerable<Attachment> Attachments { get; set; }

    public FundraisingCampaign FundraisingCampaign { get; set; }

    public AdditionalServices AdditionalServices { get; set; }

    public Stock Stock { get; set; }

    public Delivery Delivery { get; set; }

    public CompatibilityList CompatibilityList { get; set; }

    public string Language { get; set; } = "pl-PL";

    public Category Category { get; set; }

    public IEnumerable<Parameter> Parameters { get; set; }

    public AfterSalesServices AfterSalesServices { get; set; }

    public SizeTable SizeTable { get; set; }

    public Discounts Discounts { get; set; }

    public string Name { get; set; }

    public Payments Payments { get; set; }

    public SellingMode SellingMode { get; set; }

    public Location Location { get; set; }

    public IEnumerable<string> Images { get; set; }

    public Description Description { get; set; }

    public External External { get; set; }

    public Tax Tax { get; set; }

    public MessageToSellerSettings MessageToSellerSettings { get; set; }
 }
