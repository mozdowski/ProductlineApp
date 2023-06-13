using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.Order.ValueObjects;

public class BillingAddress
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public Address Address { get; set; }
}
