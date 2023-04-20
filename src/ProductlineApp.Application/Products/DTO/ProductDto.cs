using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Application.Products.DTO;

public record ProductDto(
    string Name,
    Category Category,
    decimal Price,
    int Quantity,
    Image Image,
    Brand Brand,
    string Description,
    List<Image> Gallery);
