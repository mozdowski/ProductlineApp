using FluentValidation;
using ProductlineApp.Application.Products.DTO;

namespace ProductlineApp.WebUI.Validators;

public class ProductDtoRequestValidator : AbstractValidator<AddProductDtoRequest>
{
    public ProductDtoRequestValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty();
        this.RuleFor(x => x.Description).NotEmpty();
        this.RuleFor(x => x.BrandName).NotEmpty();
        this.RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        this.RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        this.RuleFor(x => x.Sku).NotEmpty();
        this.RuleFor(x => x.Image).NotNull();
        this.RuleFor(x => x.Condition).IsInEnum();
    }
}
