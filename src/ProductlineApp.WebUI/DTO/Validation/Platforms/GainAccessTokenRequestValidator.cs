using FluentValidation;
using ProductlineApp.WebUI.DTO.Platforms;

namespace ProductlineApp.WebUI.DTO.Validation.Platforms;

public class GainAccessTokenRequestValidator : AbstractValidator<GainAccessTokenRequest>
{
    public GainAccessTokenRequestValidator()
    {
        this.RuleFor(x => x.Code)
            .NotEmpty();
    }
}
