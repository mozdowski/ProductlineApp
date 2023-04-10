using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using System.Security.Authentication;

namespace ProductlineApp.Domain.Aggregates.Listing;

public class Listing : AggregateRoot<ListingId>
{
    private readonly List<ListingInstance> _instances = new();

    private Listing(
        ListingId id,
        string title,
        string description,
        ProductId productId,
        decimal price,
        int quantity,
        UserId ownerId)
        : base(id)
    {
        this.Title = title;
        this.Description = description;
        this.ProductId = productId;
        this.Price = price;
        this.Quantity = quantity;
        this.Owner = ownerId;
        this.Status = ListingStatus.ACTIVE;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public ProductId ProductId { get; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public IReadOnlyList<ListingInstance> Instances => this._instances.AsReadOnly();

    public ListingStatus Status { get; private set; }

    public UserId Owner { get; }

    public static Listing Create(
        string title,
        string description,
        ProductId product,
        decimal price,
        int quantity,
        UserId ownerId,
        PlatformConnectionId platformConnection)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.", nameof(price));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        var id = ListingId.CreateUnique();

        return new Listing(
            id,
            title,
            description,
            product,
            price,
            quantity,
            ownerId);
    }

    public static Listing CreateFromProduct(Product.Product product, UserId ownerId)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        if (product.OwnerId != ownerId)
            throw new InvalidCredentialException("Product owner does not match Listing owner");

        var id = ListingId.CreateUnique();
        var title = product.Name;
        var description = product.Description;
        var price = product.Price;
        var quantity = product.Quantity;

        return new Listing(
            id,
            title,
            description,
            product.Id,
            price,
            quantity,
            ownerId);
    }

    public void Update(
        string title,
        string description,
        decimal price,
        int quantity)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.", nameof(price));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        this.Title = title;
        this.Description = description;
        this.Price = price;
        this.Quantity = quantity;
    }

    public void MarkAsInactive()
    {
        if (this.Status != ListingStatus.ACTIVE)
            throw new InvalidOperationException("Listing is not active.");

        this.Status = ListingStatus.INACTIVE;
    }

    public void MarkAsSold()
    {
        if (this.Status != ListingStatus.ACTIVE)
            throw new InvalidOperationException("Listing is not active.");

        this.Status = ListingStatus.SOLD;
    }

    public void AddInstance(ListingInstance instance)
    {
        if (instance is null)
            throw new ArgumentNullException(nameof(instance));

        this._instances.Add(instance);
    }

    public void RemoveInstance(ListingInstance instance)
    {
        if (instance is null)
            throw new ArgumentNullException(nameof(instance));

        this._instances.Remove(instance);
    }
}

