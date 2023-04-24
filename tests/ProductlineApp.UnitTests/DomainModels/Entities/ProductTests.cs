namespace ProductlineApp.UnitTests.DomainModels.Entities;

// [TestFixture]
// public class ProductTests
// {
//     private Product _product;
//
//     [SetUp]
//     public void Setup()
//     {
//         // Arrange
//         var ownerId = UserId.CreateUnique();
//         this._product = Product.Create("ABC123", "Test Product", "Test Category", 9.99m, 10, "https://example.com/image.jpg",
//             "Test Brand", "Test Description", ownerId);
//     }
//
//     [Test]
//     public void Create_ValidParameters_ReturnsProductWithExpectedProperties()
//     {
//         // Assert
//         Assert.IsNotNull(this._product.Id);
//         Assert.AreEqual("Test Product", this._product.Name);
//         Assert.AreEqual("Test Category".ToLower(), this._product.Category.Name);
//         Assert.AreEqual(9.99m, this._product.Price);
//         Assert.AreEqual(10, this._product.Quantity);
//         Assert.AreEqual("https://example.com/image.jpg", this._product.Image.Url.ToString());
//         Assert.AreEqual("Test Brand".ToLower(), this._product.Brand.Name);
//         Assert.AreEqual("Test Description", this._product.Description);
//         Assert.IsFalse(this._product.IsListed);
//         Assert.IsEmpty(this._product.Gallery);
//     }
//
//     [Test]
//     public void Create_InvalidParameters_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => Product.Create("", "Test Category", 9.99m, 10,
//             "https://example.com/image.jpg", "Test Brand", "Test Description", UserId.CreateUnique()));
//     }
//
//     [Test]
//     public void AddImageToGalleryByUrl_ValidUrl_AddsImageToGallery()
//     {
//         // Act
//         this._product.AddImageToGalleryByUrl("https://example.com/gallery-image.jpg");
//
//         // Assert
//         Assert.AreEqual(1, this._product.Gallery.Count);
//         Assert.AreEqual("https://example.com/gallery-image.jpg", this._product.Gallery[0].Url.ToString());
//     }
//
//     [Test]
//     public void RemoveImageFromGalleryByUrl_ValidUrl_RemovesImageFromGallery()
//     {
//         // Arrange
//         this._product.AddImageToGalleryByUrl("https://example.com/gallery-image.jpg");
//
//         // Act
//         this._product.RemoveImageFromGalleryByUrl("https://example.com/gallery-image.jpg");
//
//         // Assert
//         Assert.IsEmpty(this._product.Gallery);
//     }
//
//     [Test]
//     public void ClearGallery_GalleryContainsImages_RemovesAllImagesFromGallery()
//     {
//         // Arrange
//         this._product.AddImageToGalleryByUrl("https://example.com/gallery-image-1.jpg");
//         this._product.AddImageToGalleryByUrl("https://example.com/gallery-image-2.jpg");
//
//         // Act
//         this._product.ClearGallery();
//
//         // Assert
//         Assert.IsEmpty(this._product.Gallery);
//     }
//
//     [Test]
//     public void Update_ValidParameters_UpdatesProductProperties()
//     {
//         // Act
//         this._product.Update("Updated Product", "Updated Category", 19.99m, 20, "https://example.com/updated-image.jpg",
//             "Updated Brand", "Updated Description");
//
//         // Assert
//         Assert.AreEqual("Updated Product", this._product.Name);
//         Assert.AreEqual("Updated Category".ToLower(), this._product.Category.Name);
//         Assert.AreEqual(19.99m, this._product.Price);
//         Assert.AreEqual(20, this._product.Quantity);
//         Assert.AreEqual("https://example.com/updated-image.jpg", this._product.Image.Url.ToString());
//         Assert.AreEqual("Updated Brand".ToLower(), this._product.Brand.Name);
//         Assert.AreEqual("Updated Description", this._product.Description);
//     }
//
//     [Test]
//     public void Update_InvalidName_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => this._product.Update("", "Updated Category", 19.99m, 20, "https://example.com/updated-image.jpg", "Updated Brand", "Updated Description"));
//     }
//
//     [Test]
//     public void Update_InvalidCategory_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => this._product.Update("Updated Product", "", 19.99m, 20, "https://example.com/updated-image.jpg", "Updated Brand", "Updated Description"));
//     }
//
//     [Test]
//     public void Update_InvalidPrice_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => this._product.Update("Updated Product", "Updated Category", -19.99m, 20, "https://example.com/updated-image.jpg", "Updated Brand", "Updated Description"));
//     }
//
//     [Test]
//     public void Update_InvalidQuantity_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => this._product.Update("Updated Product", "Updated Category", 19.99m, -20, "https://example.com/updated-image.jpg", "Updated Brand", "Updated Description"));
//     }
//
//     [Test]
//     public void Update_InvalidImageUrl_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => this._product.Update("Updated Product", "Updated Category", 19.99m, 20, "", "Updated Brand", "Updated Description"));
//     }
//
//     [Test]
//     public void Update_InvalidBrand_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => this._product.Update("Updated Product", "Updated Category", 19.99m, 20, "https://example.com/updated-image.jpg", "", "Updated Description"));
//     }
//
//     [Test]
//     public void Update_InvalidDescription_ThrowsArgumentException()
//     {
//         // Assert
//         Assert.Throws<ArgumentException>(() => this._product.Update("Updated Product", "Updated Category", 19.99m, 20, "https://example.com/updated-image.jpg", "Updated Brand", ""));
//     }
// }
