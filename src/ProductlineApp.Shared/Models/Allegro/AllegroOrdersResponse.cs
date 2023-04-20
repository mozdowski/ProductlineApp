namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroOrdersResponse
{
    public IEnumerable<CheckoutForm> CheckoutForms { get; set; }

    public int Count { get; set; }

    public int TotalCount { get; set; }
}

public class CheckoutForm
{
    public string Id { get; set; }

    public string MessageToSeller { get; set; }

    public Buyer Buyer { get; set; }

    public Payment Payment { get; set; }

    public string Status { get; set; }

    public Fulfillment Fulfillment { get; set; }

    public OrderDelivery Delivery { get; set; }

    public Invoice Invoice { get; set; }

    public IEnumerable<LineItem> LineItems { get; set; }

    public IEnumerable<Surcharge> Surcharges { get; set; }

    public IEnumerable<Discount> Discounts { get; set; }

    public Marketplace Marketplace { get; set; }

    public Summary Summary { get; set; }

    public string UpdatedAt { get; set; }

    public string Revision { get; set; }
}

public class Buyer
{
    public string Id { get; set; }

    public string Email { get; set; }

    public string Login { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public object CompanyName { get; set; }

    public bool Guest { get; set; }

    public string PersonalIdentity { get; set; }

    public object PhoneNumber { get; set; }

    public Preferences Preferences { get; set; }

    public Address Address { get; set; }
}

public class Preferences
{
    public string Language { get; set; }
}

public class Address
{
    public string Street { get; set; }

    public string City { get; set; }

    public string PostCode { get; set; }

    public string CountryCode { get; set; }
}

public class PaidAmount
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Reconciliation
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Payment
{
    public string Id { get; set; }

    public string Type { get; set; }

    public string Provider { get; set; }

    public string FinishedAt { get; set; }

    public PaidAmount PaidAmount { get; set; }

    public Reconciliation Reconciliation { get; set; }
}

public class ShipmentSummary
{
    public string LineItemsSent { get; set; }
}

public class Fulfillment
{
    public string Status { get; set; }

    public ShipmentSummary ShipmentSummary { get; set; }
}

public class Method
{
    public string Id { get; set; }

    public string Name { get; set; }
}

public class Address2
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public string CountryCode { get; set; }

    public object CompanyName { get; set; }

    public object PhoneNumber { get; set; }

    public object ModifiedAt { get; set; }
}

public class PickupPoint
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Address2 Address { get; set; }
}

public class Cost
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Guaranteed
{
    public string From { get; set; }

    public string To { get; set; }
}

public class Time
{
    public Guaranteed Guaranteed { get; set; }
}

public class OrderDelivery
{
    public Address2 Address { get; set; }

    public Method Method { get; set; }

    public PickupPoint PickupPoint { get; set; }

    public Cost Cost { get; set; }

    public Time Time { get; set; }

    public bool Smart { get; set; }

    public int CalculatedNumberOfPackages { get; set; }
}

public class Company
{
    public string Name { get; set; }

    public object TaxId { get; set; }
}

public class NaturalPerson
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

public class Address3
{
    public string Street { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public string CountryCode { get; set; }

    public Company Company { get; set; }

    public NaturalPerson NaturalPerson { get; set; }
}

public class Invoice
{
    public bool Required { get; set; }

    public Address3 Address { get; set; }

    public DateTime DueDate { get; set; }
}

public class Offer
{
    public string Id { get; set; }

    public string Name { get; set; }

    public External External { get; set; }
}

public class External
{
    public string Id { get; set; }
}

public class OriginalPrice
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Value
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Reconciliation2
{
    public Value Value { get; set; }

    public string Type { get; set; }

    public int Quantity { get; set; }
}

public class Price
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class SelectedAdditionalService
{
    public string DefinitionId { get; set; }

    public string Name { get; set; }

    public Price Price { get; set; }

    public int Quantity { get; set; }
}

public class LineItem
{
    public string Id { get; set; }

    public Offer Offer { get; set; }

    public int Quantity { get; set; }

    public OriginalPrice OriginalPrice { get; set; }

    public Price Price { get; set; }

    public Reconciliation2 Reconciliation { get; set; }

    public List<SelectedAdditionalService> SelectedAdditionalServices { get; set; }

    public DateTime BoughtAt { get; set; }
}

public class PaidAmount2
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Reconciliation3
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Surcharge
{
    public string Id { get; set; }

    public string Type { get; set; }

    public string Provider { get; set; }

    public string FinishedAt { get; set; }

    public PaidAmount2 PaidAmount { get; set; }

    public Reconciliation3 Reconciliation { get; set; }
}

public class Discount
{
    public string Type { get; set; }
}

public class TotalToPay
{
    public string Amount { get; set; }

    public string Currency { get; set; }
}

public class Summary
{
    public TotalToPay TotalToPay { get; set; }
}

public class Marketplace
{
    public string Id { get; set; }
}
