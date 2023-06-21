namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroCreateListingRequest
{
    public IEnumerable<ProductSet> ProductSet { get; set; }

    public B2b B2b { get; set; }

    public IEnumerable<Attachment> Attachments { get; set; }

    public FundraisingCampaign FundraisingCampaign { get; set; }

    public AdditionalServices AdditionalServices { get; set; }

    public Stock Stock { get; set; }

    public Delivery Delivery { get; set; }

    public Publication Publication { get; set; }

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

public class Category
{
    public string Id { get; set; }
}

public class RangeValue
{
    public string From { get; set; }

    public string To { get; set; }
}

public class Parameter
{
    public string Id { get; set; }

    public string Name { get; set; }

    public List<string> Values { get; set; }

    public List<string> ValuesIds { get; set; }
}

public class AllegroListingProduct
{
    public string Name { get; set; }

    public Category Category { get; set; }

    public string Id { get; set; }

    public string IdType { get; set; }

    public List<Parameter> Parameters { get; set; }

    public List<string> Images { get; set; }
}

public class Quantity
{
    public int Value { get; set; }
}

public class ProductSet
{
    public AllegroListingProduct Product { get; set; }

    public Quantity Quantity { get; set; }
}

public class B2b
{
    public bool BuyableOnlyByBusiness { get; set; } = false;
}

public class Attachment
{
    public string Id { get; set; }
}

public class FundraisingCampaign
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class AdditionalServices
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class Stock
{
    public int Available { get; set; }

    public string Unit { get; set; } = "UNIT";
}

public class Delivery
{
    public string HandlingTime { get; set; }

    public ShippingRate ShippingRates { get; set; }

    public string AdditionalInfo { get; set; }

    public DateTime ShipmentDate { get; set; }

    public class ShippingRate
    {
        public string Name { get; set; }
    }
}

public class Publication
{
    public string Duration { get; set; }

    public DateTime? StartingAt { get; set; }

    public string Status { get; set; }

    public bool Republish { get; set; }
}

public class Item
{
    public string Type { get; set; }

    public string Text { get; set; }
}

public class CompatibilityList
{
    public List<Item> Items { get; set; }
}

public class ImpliedWarranty
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class ReturnPolicy
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class Warranty
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class AfterSalesServices
{
    public ImpliedWarranty ImpliedWarranty { get; set; }

    public ReturnPolicy ReturnPolicy { get; set; }

    public Warranty Warranty { get; set; }
}

public class SizeTable
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class WholesalePriceList
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class Discounts
{
    public WholesalePriceList WholesalePriceList { get; set; }
}

public class Payments
{
    public string Invoice { get; set; }

    public enum PaymentInvoice
    {
        VAT,
        VAT_MARGIN,
        WITHOUT_VAT,
        NO_INVOICE,
    }
}

public class SellingMode
{
    public string Format { get; set; }

    public Price Price { get; set; }

    public Price MinimalPrice { get; set; }

    public Price StartingPrice { get; set; }
}

public class Location
{
    public string City { get; set; }

    public string CountryCode { get; set; }

    public string PostCode { get; set; }

    public string Province { get; set; }
}

public class Description
{
    public List<Section> Sections { get; set; }
}

public class Section
{
    public List<Item2> Items { get; set; }
}

public class Item2
{
    public string Type { get; set; }

    public string Content { get; set; }
}

public class Tax
{
    public string Id { get; set; }

    public string Rate { get; set; }

    public string Subject { get; set; }

    public string Exemption { get; set; }

    public string Percentage { get; set; }
}

public class MessageToSellerSettings
{
    public string Mode { get; set; }
}
