using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Shared.Binders;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Products.DTO;

public class AddProductDtoRequest
{
    public string Sku { get; set; }

    public string Name { get; set; }

    public string CategoryName { get; set; }

    [ModelBinder(BinderType = typeof(DecimalModelBinder))]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public IFormFile Image { get; set; }

    public string BrandName { get; set; }

    public string Description { get; set; }

    public ProductCondition Condition { get; set; }
}
