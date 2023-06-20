namespace ProductlineApp.Domain.ValueObjects;

public record Address
{
    public Address(string streetName, string streetNumber, string zip, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(streetName))
        {
            throw new ArgumentException("Street name must be provided.", nameof(streetName));
        }

        if (string.IsNullOrWhiteSpace(streetNumber))
        {
            throw new ArgumentException("Street number must be provided.", nameof(streetNumber));
        }

        if (string.IsNullOrWhiteSpace(zip))
        {
            throw new ArgumentException("Zip code must be provided.", nameof(zip));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City must be provided.", nameof(city));
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException("Country must be provided.", nameof(country));
        }

        this.StreetName = streetName;
        this.StreetNumber = streetNumber;
        this.Zip = zip;
        this.City = city;
        this.Country = country;
    }

    public Address(string streetName, string zip, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(streetName))
        {
            throw new ArgumentException("Street name must be provided.", nameof(streetName));
        }

        if (string.IsNullOrWhiteSpace(zip))
        {
            throw new ArgumentException("Zip code must be provided.", nameof(zip));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City must be provided.", nameof(city));
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException("Country must be provided.", nameof(country));
        }

        this.StreetName = streetName;
        this.Zip = zip;
        this.City = city;
        this.Country = country;
    }

    public Address()
    {
    }

    public Address(string addressString)
    {
        var address = addressString.Split(",");
        this.StreetName = address[0].Trim();
        this.StreetNumber = address[1].Trim();
        this.Zip = address[2].Trim();
        this.City = address[3].Trim();
        this.Country = address[4].Trim();
    }

    public string StreetName { get; private set; }

    public string StreetNumber { get; private set; }

    public string Zip { get; private set; }

    public string City { get; private set; }

    public string Country { get; private set; }

    public override string ToString()
    {
        return string.Join(
            ", ",
            new string?[] { this.StreetName, this.StreetNumber, this.Zip, this.City, this.Country });
    }
}
