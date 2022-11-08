using ProductlineApp.Domain.Common;

namespace ProductlineApp.Domain.Entities;

public class IndividualBuyer : Person
{
    public IndividualBuyer(
        Guid id,
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth)
        : base(id, firstName, lastName, email, dateOfBirth)
    {
    }
}
