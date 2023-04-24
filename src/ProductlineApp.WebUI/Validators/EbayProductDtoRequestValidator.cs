using FluentValidation;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.WebUI.Validators;

public class EbayProductDtoRequestValidator : AbstractValidator<EbayProductDtoRequest>
{
    public EbayProductDtoRequestValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty();
        this.RuleFor(x => x.Description).NotEmpty();
        this.RuleFor(x => x.BrandName).NotEmpty();
        this.RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        this.RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        this.RuleFor(x => x.Sku).NotEmpty();
        this.RuleFor(x => x.Image).NotNull();
    }
}
