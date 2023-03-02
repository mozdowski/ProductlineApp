using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Entities;

public class Product : AggregateRoot
{
    public Product(
        string productId,
        string name,
        Category category,
        decimal price,
        int? quantity,
        Image image,
        string? brand,
        string? description,
        Seller owner)
    {
        this.ProductId = productId;
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

    public string ProductId { get; private set; }

    public string Name { get; private set; }

    public Category Category { get; private set; }

    public decimal Price { get; private set; }

    public int? Quantity { get; private set; }

    public Image Image { get; private set; }

    public ProductStatus Status { get; private set; }

    public string? Brand { get; private set; }

    public string? Description { get; private set; }

    public Seller Owner { get; private set; }
}
