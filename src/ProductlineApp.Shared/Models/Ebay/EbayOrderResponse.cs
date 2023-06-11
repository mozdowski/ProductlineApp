namespace ProductlineApp.Shared.Models.Ebay;

public class EbayOrderResponse
{
    public string OrderId { get; set; }

    public DateTime CreationDate { get; set; }

    public List<FulfillmentStartInstruction> FulfillmentStartInstructions { get; set; }

    public List<LineItem> LineItems { get; set; }

    public EbayOrderBuyer Buyer { get; set; }

    public EbayOrderPricingSummary PricingSummary { get; set; }

    public string OrderFulfillmentStatus { get; set; }

    public EbayOrderTotalFeeBasisAmount TotalFeeBasisAmount { get; set; }

    public class FulfillmentStartInstruction
    {
        public DateTime MaxEstimatedDeliveryDate { get; set; }

        public ShippingStep ShippingStep { get; set; }
    }

    public class ShippingStep
    {
        public ShipTo ShipTo { get; set; }
    }

    public class ShipTo
    {
        public string FullName { get; set; }

        public ContactAddress ContactAddress { get; set; }

        public PrimaryPhone PrimaryPhone { get; set; }

        public string Email { get; set; }
    }

    public class ContactAddress
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string StateOrProvince { get; set; }

        public string PostalCode { get; set; }

        public string CountryCode { get; set; }
    }

    public class PrimaryPhone
    {
        public string PhoneNumber { get; set; }
    }

    public class LineItem
    {
        public string Sku { get; set; }

        public string Title { get; set; }

        public LineItemCost LineItemCost { get; set; }

        public int Quantity { get; set; }

        public DeliveryCost DeliveryCost { get; set; }

        public Total Total { get; set; }

        public string LineItemFulfillmentStatus { get; set; }
    }

    public class LineItemCost
    {
        public string Value { get; set; }

        public string Currency { get; set; }
    }

    public class DeliveryCost
    {
        public ShippingCost ShippingCost { get; set; }
    }

    public class ShippingCost
    {
        public string Value { get; set; }

        public string Currency { get; set; }
    }

    public class Total
    {
        public string Value { get; set; }

        public string Currency { get; set; }
    }

    public class EbayOrderBuyer
    {
        public string Username { get; set; }

        public BuyerRegistrationAddress BuyerRegistrationAddress { get; set; }
    }

    public class BuyerRegistrationAddress
    {
        public string FullName { get; set; }

        public ContactAddress ContactAddress { get; set; }

        public PrimaryPhone PrimaryPhone { get; set; }

        public string Email { get; set; }
    }

    public class EbayOrderPricingSummary
    {
        public PriceSubtotal PriceSubtotal { get; set; }

        public DeliveryCost DeliveryCost { get; set; }

        public Total Total { get; set; }
    }

    public class PriceSubtotal
    {
        public string Value { get; set; }

        public string Currency { get; set; }
    }

    public class EbayOrderTotalFeeBasisAmount
    {
        public string Value { get; set; }

        public string Currency { get; set; }
    }
}
