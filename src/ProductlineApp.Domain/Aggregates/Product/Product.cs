using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.Product;

public class Product : AggregateRoot<ProductId>
{
    private readonly List<Image> _gallery = new();

    private Product(
        ProductId id,
        string sku,
        string name,
        Category category,
        decimal price,
        int quantity,
        Image image,
        Brand brand,
        string description,
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
    }

    public ProductId Id { get; }

    public string Name { get; private set; }

    public Category Category { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public Image Image { get; private set; }

    public IReadOnlyList<Image> Gallery => this._gallery.AsReadOnly();

    public bool IsListed { get; private set; }

    public Brand Brand { get; private set; }

    public string Description { get; private set; }

    public UserId OwnerId { get; }

    public string Sku { get; }

    public static Product Create(
        string sku,
        string name,
        string categoryName,
        decimal price,
        int quantity,
        Image image,
        string brandName,
        string description,
        UserId ownerId)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(categoryName) || price < 0 || (quantity < 0) ||
            string.IsNullOrEmpty(description) || string.IsNullOrEmpty(brandName))
            throw new ArgumentException("Invalid input parameters");

        var id = ProductId.CreateUnique();
        var category = new Category(categoryName);
        var brand = new Brand(brandName);

        return new Product(
            id,
            sku,
            name,
            category,
            price,
            quantity,
            image,
            brand,
            description,
            ownerId);
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

    public void Update(
        string name,
        string categoryName,
        decimal price,
        Image image,
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
        this.Image = image;
        this.Brand = new Brand(brandName);
        this.Description = description;
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
}
