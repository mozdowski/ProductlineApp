using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Common.Mappings;

public record ProductResponseMapperInput(Product Product, IEnumerable<string> Platforms);
