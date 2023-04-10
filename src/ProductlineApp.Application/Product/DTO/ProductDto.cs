using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Application.Product.DTO;

public record ProductDto(
    string Name,
    Category Category,
    decimal Price,
    int Quantity,
    Image Image,
    Brand Brand,
    string Description,
    List<Image> Gallery);
