namespace ProductlineApp.Domain.Aggregates.Product.ValueObjects;

public record Category
{
    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be null or empty.");

        this.Name = name.Trim().ToLower();
    }

    public string Name { get; }
}
