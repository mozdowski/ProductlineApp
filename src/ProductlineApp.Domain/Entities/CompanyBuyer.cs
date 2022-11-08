using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Entities;
public class CompanyBuyer : Entity
{
    public CompanyBuyer(
        Guid id,
        string name,
        string registrationNumber,
        Address address)
        : base(id)
    {
        this.Name = name;
        this.RegistrationNumber = registrationNumber;
        this.Address = address;
    }

    public string Name { get; private set; }

    public string RegistrationNumber { get; private set; }

    public Address Address { get; private set; }
}
