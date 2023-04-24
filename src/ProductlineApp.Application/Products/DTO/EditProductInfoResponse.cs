using ProductlineApp.Domain.Aggregates.Products.ValueObjects;

namespace ProductlineApp.Application.Products.DTO;

public record EditProductInfoResponse(string Name,
                                    Category Category,
                                    decimal Price,
                                    int Quantity,
                                    Brand Brand,
                                    string Description);
