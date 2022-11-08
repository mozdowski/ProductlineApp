using System.ComponentModel.DataAnnotations;

namespace ProductlineApp.Domain.Common;

public abstract class Person : Entity
{
    protected Person(
        Guid id,
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth)
        : base(id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public DateTime DateOfBirth { get; set; }
}
