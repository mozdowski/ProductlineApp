using Microsoft.AspNetCore.Http;

namespace ProductlineApp.Application.Products.DTO;

public record EditProductDtoRequest(
    string Name,
    string CategoryName,
    decimal Price,
    int Quantity,
    string BrandName,
    string Description);
