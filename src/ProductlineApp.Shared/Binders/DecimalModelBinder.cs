using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProductlineApp.Shared.Binders;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        var stringValue = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(stringValue))
        {
            return Task.CompletedTask;
        }

        decimal decimalValue;
        var culture = CultureInfo.InvariantCulture;
        var style = NumberStyles.Number;

        if (decimal.TryParse(stringValue, style, culture, out decimalValue))
        {
            bindingContext.Result = ModelBindingResult.Success(decimalValue);
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Invalid decimal value.");
        }

        return Task.CompletedTask;
    }
}
