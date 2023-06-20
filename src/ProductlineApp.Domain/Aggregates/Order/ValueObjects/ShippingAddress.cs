using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.Order.ValueObjects;

public class ShippingAddress
{
    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? CompanyName { get; set; }

    public string PhoneNumber { get; set; }

    public Address Address { get; set; }
}
