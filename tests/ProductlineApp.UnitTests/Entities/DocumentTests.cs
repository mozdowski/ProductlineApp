namespace ProductlineApp.UnitTests.Entities;

using System;
using NUnit.Framework;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

[TestFixture]
public class DocumentTests
{
    private DocumentId _documentId;
    private OrderId _orderId;
    private string _name;
    private Uri _url;

    [SetUp]
    public void SetUp()
    {
        this._documentId = DocumentId.CreateUnique();
        this._orderId = OrderId.CreateUnique();
        this._name = "Example Document";
        this._url = new Uri("https://example.com/document.pdf");
    }

    [Test]
    public void Create_WithValidParameters_CreatesDocument()
    {
        // Act
        var document = Document.Create(this._name, this._url.ToString(), this._orderId);

        // Assert
        Assert.AreEqual(this._name, document.Name);
        Assert.AreEqual(this._url, document.Url);
        Assert.AreEqual(this._orderId, document.OrderId);
    }

    [Test]
    public void Create_WithNullName_ThrowsArgumentException()
    {
        // Arrange
        string name = null;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Document.Create(name, this._url.ToString(), this._orderId));
    }

    [Test]
    public void Create_WithInvalidUrl_ThrowsArgumentException()
    {
        // Arrange
        var url = "invalid_url";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Document.Create(this._name, url, this._orderId));
    }
}
