using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Domain.Aggregates.Products;

public class Product : AggregateRoot<ProductId>
{
    const int MaxProductImages = 10;
    private readonly List<Image> _gallery = new(MaxProductImages);

    private Product(
        ProductId id,
        string sku,
        string name,
        Category? category,
        decimal price,
        int quantity,
        Image image,
        Brand brand,
        string description,
        ProductCondition condition,
        UserId ownerId)
        : base(id)
    {
        this.Id = id;
        this.Sku = sku;
        this.Name = name;
        this.Category = category;
        this.Price = price;
        this.Quantity = quantity;
        this.Image = image;
        this.Brand = brand;
        this.Description = description;
        this.OwnerId = ownerId;
        this.Condition = condition;
    }

    private Product(
        ProductId id,
        string sku,
        string name,
        Category? category,
        decimal price,
        int quantity,
        Image image,
        Brand brand,
        string description,
        ProductCondition condition,
        UserId ownerId,
        IEnumerable<Image> gallery)
        : base(id)
    {
        this.Id = id;
        this.Sku = sku;
        this.Name = name;
        this.Category = category;
        this.Price = price;
        this.Quantity = quantity;
        this.Image = image;
        this.Brand = brand;
        this.Description = description;
        this.OwnerId = ownerId;
        this.Condition = condition;

        foreach (var img in gallery)
        {
            this.AddImageToGallery(img);
        }
    }

    private Product()
    {
    }

    public ProductId Id { get; private init; }

    public string Name { get; private set; }

    public Category? Category { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public Image Image { get; private set; }

    public IReadOnlyList<Image> Gallery => this._gallery.AsReadOnly();

    public bool IsListed { get; private set; }

    public Brand Brand { get; private set; }

    public string Description { get; private set; }

    public UserId OwnerId { get; private init; }

    public string Sku { get; private init; }

    public ProductCondition Condition { get; private set; }

    public static Product Create(
        string sku,
        string name,
        string? categoryName,
        decimal price,
        int quantity,
        Image image,
        string brandName,
        string description,
        ProductCondition condition,
        UserId ownerId,
        IEnumerable<Image>? gallery)
    {
        if (string.IsNullOrEmpty(name) || price < 0 || (quantity < 0) ||
            string.IsNullOrEmpty(description) || string.IsNullOrEmpty(brandName))
            throw new ArgumentException("Invalid input parameters");

        var id = ProductId.CreateUnique();
        var category = categoryName is null ? null : new Category(categoryName);
        var brand = new Brand(brandName);

        return gallery is null
            ? new Product(
                id,
                sku,
                name,
                category,
                price,
                quantity,
                image,
                brand,
                description,
                condition,
                ownerId)
            : new Product(
                id,
                sku,
                name,
                category,
                price,
                quantity,
                image,
                brand,
                description,
                condition,
                ownerId,
                gallery);
    }

    public void AddImageToGallery(Image image)
    {
        if (!this._gallery.Contains(image))
        {
            this._gallery.Add(image);
        }
    }

    public void RemoveImageFromGallery(string url)
    {
        this._gallery.RemoveAll(x => x.Url.ToString().Equals(url));
    }

    public void ClearGallery()
    {
        this._gallery.Clear();
    }

    public void UpdateInfo(
        string name,
        string categoryName,
        decimal price,
        int quantity,
        string brandName,
        string description)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(categoryName) || price < 0 || (quantity < 0) ||
            string.IsNullOrEmpty(description) || string.IsNullOrEmpty(brandName))
            throw new ArgumentException("Invalid input parameters");

        this.Name = name;
        this.Category = new Category(categoryName);
        this.Price = price;
        this.Quantity = quantity;
        this.Brand = new Brand(brandName);
        this.Description = description;
    }

    public void UpdateImage(Image image)
    {
        if (this.Image != image)
            this.Image = image;
    }

    public void MarkAsListed()
    {
        if (this.IsListed)
            throw new InvalidOperationException("Product is already marked as listed");

        this.IsListed = true;
    }

    public void MarkAsNotListed()
    {
        if (!this.IsListed)
            throw new InvalidOperationException("Product is already marked as not listed");

        this.IsListed = false;
    }

    public bool IsOwnerConsistent(UserId userId)
    {
        return this.OwnerId == userId;
    }

    public bool HasGalleryReachedMaxCapacity()
    {
        return this._gallery.Count >= MaxProductImages;
    }
}
