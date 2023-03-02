using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Application.Products.Models;

public class ProductListModel
{
    public Guid Id { get; set; }

    public string? Brand { get; set; }

    public string? Name { get; set; }

    public Category? Category { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public ProductStatus Status { get; set; }
}
