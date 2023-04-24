using FluentValidation;
using ProductlineApp.WebUI.DTO.Platforms;

namespace ProductlineApp.WebUI.Validators;

public class GainAccessTokenRequestValidator : AbstractValidator<GainAccessTokenRequest>
{
    public GainAccessTokenRequestValidator()
    {
        this.RuleFor(x => x.Code)
            .NotEmpty();
    }
}
