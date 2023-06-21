using FluentValidation;
using ProductlineApp.Shared.Models.Authentication.Requests.Auth;

namespace ProductlineApp.WebUI.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        this.RuleFor(x => x.Email).NotEmpty().EmailAddress();
        this.RuleFor(x => x.Password).NotEmpty();
    }
}
