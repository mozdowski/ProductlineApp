namespace ProductlineApp.Domain.ValueObjects;

public record Address(
    string StreetName,
    string StreetNumber,
    string Zip,
    string City,
    string Country)
{
    public override string ToString()
    {
        return string.Join(
            ", ",
            new string?[] { this.StreetName, this.StreetNumber, this.Zip, this.City, this.Country });
    }
}
