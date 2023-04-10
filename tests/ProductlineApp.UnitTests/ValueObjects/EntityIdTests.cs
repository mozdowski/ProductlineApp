namespace ProductlineApp.UnitTests.ValueObjects;

using System;
using NUnit.Framework;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

[TestFixture]
public class EntityIdTests
{
    [Test]
    public void OrderId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var orderId = OrderId.CreateUnique();
        Assert.That(orderId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void OrderId_Create_ReturnsOrderIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var orderId = OrderId.Create(guid);
        Assert.That(orderId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void DocumentId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var documentId = DocumentId.CreateUnique();
        Assert.That(documentId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void DocumentId_Create_ReturnsDocumentIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var documentId = DocumentId.Create(guid);
        Assert.That(documentId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void OrderLineId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var orderLineId = OrderLineId.CreateUnique();
        Assert.That(orderLineId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void OrderLineId_Create_ReturnsOrderLineIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var orderLineId = OrderLineId.Create(guid);
        Assert.That(orderLineId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void ProductId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var productId = ProductId.CreateUnique();
        Assert.That(productId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void ProductId_Create_ReturnsProductIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var productId = ProductId.Create(guid);
        Assert.That(productId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void UserId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var userId = UserId.CreateUnique();
        Assert.That(userId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void UserId_Create_ReturnsUserIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var userId = UserId.Create(guid);
        Assert.That(userId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void PlatformId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var platformId = PlatformId.CreateUnique();
        Assert.That(platformId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void PlatformId_Create_ReturnsPlatformIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var platformId = PlatformId.Create(guid);
        Assert.That(platformId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void PlatformConnectionId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var platformConnectionId = PlatformConnectionId.CreateUnique();
        Assert.That(platformConnectionId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void PlatformConnectionId_Create_ReturnsPlatformConnectionIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var platformConnectionId = PlatformConnectionId.Create(guid);
        Assert.That(platformConnectionId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void ListingId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var listingId = ListingId.CreateUnique();
        Assert.That(listingId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void ListingId_Create_ReturnsListingIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var listingId = ListingId.Create(guid);
        Assert.That(listingId.Value, Is.EqualTo(guid));
    }

    [Test]
    public void ListingInstanceId_CreateUnique_ReturnsNonEmptyGuid()
    {
        var listingInstanceId = ListingInstanceId.CreateUnique();
        Assert.That(listingInstanceId.Value, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void ListingInstanceId_Create_ReturnsListingIdWithSameValue()
    {
        var guid = Guid.NewGuid();
        var listingInstanceId = ListingInstanceId.Create(guid);
        Assert.That(listingInstanceId.Value, Is.EqualTo(guid));
    }
}

