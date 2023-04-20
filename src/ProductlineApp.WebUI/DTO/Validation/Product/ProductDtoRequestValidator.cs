using FluentValidation;
using ProductlineApp.WebUI.DTO.Product;

namespace ProductlineApp.WebUI.DTO.Validation.Product;

public class ProductDtoRequestValidator : AbstractValidator<ProductDtoRequest>
{
    public ProductDtoRequestValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty();
        this.RuleFor(x => x.Description).NotEmpty();
        this.RuleFor(x => x.BrandName).NotEmpty();
        this.RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        this.RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        this.RuleFor(x => x.Sku).NotEmpty();
        this.RuleFor(x => x.ImageUrl).NotEmpty();
    }
}
