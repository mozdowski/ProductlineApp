using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
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
        this.OwnerId = ownerId;
        // this.Status = ListingStatus.ACTIVE;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public ProductId ProductId { get; private init; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public IReadOnlyList<ListingInstance> Instances
    {
        get => this._instances.AsReadOnly();
        private init => this._instances = value.ToList();
    }

// public ListingStatus Status { get; private set; }

    public UserId OwnerId { get; private init; }

    public static Listing Create(
        string title,
        string description,
        ProductId product,
        decimal price,
        int quantity,
        UserId ownerId)
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

    public static Listing CreateFromProduct(Product product, UserId ownerId)
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

    public ListingInstance GetListingInstance(ListingInstanceId listingInstanceId)
    {
        var listingInstance = this._instances.FirstOrDefault(x => x.Id == listingInstanceId);
        if (listingInstance is null)
            throw new Exception($"No listing instance with ID: {listingInstanceId} found");

        return listingInstance;
    }

    public void MarkListingInstanceAsActive(ListingInstanceId listingInstanceId)
    {
        var li = this.GetListingInstance(listingInstanceId);
        li.MarkAsActive();
    }

    public void MarkListingInstanceAsInactive(ListingInstanceId listingInstanceId)
    {
        var li = this.GetListingInstance(listingInstanceId);
        li.MarkAsInactive();
    }

    // public void MarkAsInactive()
    // {
    //     if (this.Status != ListingStatus.ACTIVE)
    //         throw new InvalidOperationException("Listing is not active.");
    //
    //     this.Status = ListingStatus.INACTIVE;
    // }
    //
    // public void MarkAsSold()
    // {
    //     if (this.Status != ListingStatus.ACTIVE)
    //         throw new InvalidOperationException("Listing is not active.");
    //
    //     this.Status = ListingStatus.SOLD;
    //
    //     foreach (var instance in this._instances)
    //     {
    //         instance.Status == ListingStatus.SOLD
    //     }
    // }

    public void AddInstance(PlatformId platformId, string platformListingId, string? listingUrl, int? expiresIn)
    {
        this._instances.Add(ListingInstance.CreateAndPublish(
            this.Id,
            platformId,
            platformListingId,
            listingUrl,
            expiresIn));
    }

    public void RemoveInstance(ListingInstance instance)
    {
        if (instance is null)
            throw new ArgumentNullException(nameof(instance));

        this._instances.Remove(instance);
    }

    public bool IsUserConsistent(UserId userId)
    {
        return this.OwnerId == userId;
    }
}
