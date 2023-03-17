using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Entities;

public class Product : AggregateRoot<ProductId>
{
    public Product(
        string name,
        Category category,
        decimal price,
        int? quantity,
        Uri image,
        Brand brand,
        string? description,
        UserId owner)
        : base()
    {
        this.Name = name;
        this.Category = category;
        this.Price = price;
        this.Quantity = quantity;
        this.Image = image;
        this.Brand = brand;
        this.Description = description;
        this.Owner = owner;
        this.Status = ProductStatus.OFF_AUCTION;
    }

    public int ProductId { get; private set; }

    public string Name { get; private set; }

    public Category Category { get; private set; }

    public decimal Price { get; private set; }

    public int? Quantity { get; private set; }

    public Uri Image { get; private set; }

    public ProductStatus Status { get; private set; }

    public Brand Brand { get; private set; }

    public string? Description { get; private set; }

    public UserId Owner { get; private set; }
}
