using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;

namespace ProductlineApp.Application.Common;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IResultCommand<TResponse>, ICommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => this._validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!this._validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errors = this._validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}
