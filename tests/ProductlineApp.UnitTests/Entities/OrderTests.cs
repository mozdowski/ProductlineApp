using ProductlineApp.Domain.Aggregates.Products.ValueObjects;

namespace ProductlineApp.UnitTests.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Order;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

[TestFixture]
public class OrderTests
{
    private ListingInstanceId _listingInstanceId;
    private UserId _ownerId;
    private List<OrderLine> _orderLines;
    private Address _shippingAddress;

    [SetUp]
    public void SetUp()
    {
        this._listingInstanceId = ListingInstanceId.CreateUnique();
        this._ownerId = UserId.CreateUnique();
        this._orderLines = new List<OrderLine>
        {
            OrderLine.Create(
                ListingInstanceId.CreateUnique(),
                OrderId.CreateUnique(),
                ProductId.CreateUnique(),
                1,
                10m),
            OrderLine.Create(
                ListingInstanceId.CreateUnique(),
                OrderId.CreateUnique(),
                ProductId.CreateUnique(),
                2,
                20m),
        };
        this._shippingAddress = new Address("123 Main St", "Apt 4", "12345", "Anytown", "USA");
    }

    [Test]
    public void Create_WithValidArguments_CreatesOrder()
    {
        var order = Order.Create(this._listingInstanceId, this._ownerId, this._orderLines, this._shippingAddress);

        Assert.IsNotNull(order.Id);
        Assert.AreEqual(this._listingInstanceId, order.ListingInstanceId);
        Assert.AreEqual(this._ownerId, order.OwnerId);
        Assert.AreEqual(this._orderLines.Count, order.OrderLines.Count);
        Assert.AreEqual(this._shippingAddress, order.ShippingAddress);
    }

    [Test]
    public void Create_WithEmptyOrderLines_ThrowsArgumentException()
    {
        var emptyOrderLines = Enumerable.Empty<OrderLine>();

        Assert.Throws<ArgumentException>(() =>
        {
            Order.Create(this._listingInstanceId, this._ownerId, emptyOrderLines, this._shippingAddress);
        });
    }

    [Test]
    public void AddOrderLine_WithValidOrderLine_AddsOrderLineToOrder()
    {
        var order = Order.Create(this._listingInstanceId, this._ownerId, this._orderLines, this._shippingAddress);
        var orderLine = OrderLine.Create(
            ListingInstanceId.CreateUnique(),
            OrderId.CreateUnique(),
            ProductId.CreateUnique(),
            3,
            30m);

        order.AddOrderLine(orderLine);

        Assert.AreEqual(this._orderLines.Count + 1, order.OrderLines.Count);
        Assert.IsTrue(order.OrderLines.Contains(orderLine));
    }

    [Test]
    public void AddOrderLine_WithNullOrderLine_ThrowsArgumentNullException()
    {
        var order = Order.Create(this._listingInstanceId, this._ownerId, this._orderLines, this._shippingAddress);

        Assert.Throws<ArgumentNullException>(() =>
        {
            order.AddOrderLine(null);
        });
    }

    [Test]
    public void AddDocument_WithValidDocument_AddsDocumentToOrder()
    {
        var order = Order.Create(this._listingInstanceId, this._ownerId, this._orderLines, this._shippingAddress);
        var document = Document.Create(
            "Test Document",
            "https://example.com/document.pdf",
            order.Id);

        order.AddDocument(document);

        Assert.AreEqual(1, order.Documents.Count);
        Assert.IsTrue(order.Documents.Contains(document));
    }

    [Test]
    public void AddDocument_WithNullDocument_ThrowsArgumentNullException()
    {
        var order = Order.Create(this._listingInstanceId, this._ownerId, this._orderLines, this._shippingAddress);

        Assert.Throws<ArgumentNullException>(() =>
        {
            order.AddDocument(null);
        });
    }
}
