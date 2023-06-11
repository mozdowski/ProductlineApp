using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Shared.Enums;
using DecimalModelBinder = ProductlineApp.Shared.Binders.DecimalModelBinder;

namespace ProductlineApp.Shared.Models.Ebay;

public class EbayProductDtoRequest
{
    public string Sku { get; set; }

    public string Name { get; set; }

    public string? CategoryName { get; set; }

    [ModelBinder(BinderType = typeof(DecimalModelBinder))]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public IFormFile Image { get; set; }

    public string BrandName { get; set; }

    public string Description { get; set; }

    public ICollection<IFormFile> Images { get; set; }

    public ProductCondition Condition { get; set; }
}
