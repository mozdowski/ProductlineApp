// using System;
// using NUnit.Framework;
// using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
// using ProductlineApp.Domain.Aggregates.Order.Entities;
// using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
// using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
//
// namespace ProductlineApp.UnitTests.DomainModels.Entities;
//
// [TestFixture]
// public class OrderLineTests
// {
//     private ListingInstanceId _listingInstanceId;
//     private OrderId _orderId;
//     private ProductId _productId;
//     private int _quantity;
//     private decimal _price;
//
//     [SetUp]
//     public void SetUp()
//     {
//         this._listingInstanceId = ListingInstanceId.CreateUnique();
//         this._orderId = OrderId.CreateUnique();
//         this._productId = ProductId.CreateUnique();
//         this._quantity = 3;
//         this._price = 5.5m;
//     }
//
//     [Test]
//     public void Create_WithValidParameters_ShouldCreateOrderLine()
//     {
//         // Arrange
//
//         // Act
//         var orderLine = OrderLine.Create(this._listingInstanceId, this._orderId, this._productId, this._quantity, this._price);
//
//         // Assert
//         Assert.IsNotNull(orderLine);
//         Assert.AreEqual(this._listingInstanceId, orderLine.ListingInstanceId);
//         Assert.AreEqual(this._orderId, orderLine.OrderId);
//         Assert.AreEqual(this._productId, orderLine.ProductId);
//         Assert.AreEqual(this._quantity, orderLine.Quantity);
//         Assert.AreEqual(this._price, orderLine.Price);
//     }
//
//     [Test]
//     public void Quantity_SetLessThanMinimum_ShouldThrowArgumentException()
//     {
//         // Arrange\
//         var minQuantity = 1;
//         var orderLine = OrderLine.Create(this._listingInstanceId, this._orderId, this._productId, this._quantity, this._price);
//
//         // Act
//         var ex = Assert.Throws<ArgumentException>(() => orderLine.Quantity = 0);
//
//         // Assert
//         StringAssert.Contains($"Quantity cannot be less than {minQuantity}", ex.Message);
//     }
//
//     [Test]
//     public void TotalAmount_Get_ShouldReturnCorrectTotalAmount()
//     {
//         // Arrange
//         var orderLine = OrderLine.Create(this._listingInstanceId, this._orderId, this._productId, this._quantity, this._price);
//
//         // Act
//         var totalAmount = orderLine.TotalAmount;
//
//         // Assert
//         Assert.AreEqual(this._quantity * this._price, totalAmount);
//     }
// }
