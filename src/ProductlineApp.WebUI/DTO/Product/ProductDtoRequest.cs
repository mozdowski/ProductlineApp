namespace ProductlineApp.WebUI.DTO.Product;

public record ProductDtoRequest(string Sku,
                                string Name,
                                string? CategoryName,
                                decimal Price,
                                int Quantity,
                                string ImageUrl,
                                string BrandName,
                                string Description,
                                ICollection<string> ImageUrls);
