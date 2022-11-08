using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Entities;

public class Product : Entity
{
    public Product(
        Guid id,
        string name,
        Category category,
        decimal price,
        int quantity,
        Image image,
        string? brand,
        Seller owner)
        : base(id)
    {
        this.Name = name;
        this.Category = category;
        this.Price = price;
        this.Quantity = quantity;
        this.Image = image;
        this.Brand = brand;
        this.Owner = owner;
        this.Status = ProductStatus.OFF_AUCTION;
    }

    public string Name { get; private set; }

    public Category Category { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public Image Image { get; private set; }

    public ProductStatus Status { get; private set; }

    public string? Brand { get; private set; }

    public Seller Owner { get; private set; }
}
