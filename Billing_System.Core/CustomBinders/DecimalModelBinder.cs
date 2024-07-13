namespace Billing_System.Core.CustomBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Globalization;
    using System.Threading.Tasks;

    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            ValueProviderResult valueProviderResult =
                bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None
                && !string.IsNullOrWhiteSpace(valueProviderResult.FirstValue))
            {
                decimal parsedValue = 0m;
                bool successBinding = false;
                try
                {
                    string value = valueProviderResult.FirstValue;
                    if (value.Contains(','))
                    {
                        value = value.Replace(",",
                            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        value = value.Replace(".", 
                            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    }
                    parsedValue = Convert.ToDecimal(value, CultureInfo.CurrentCulture);
                    successBinding = true;
                }
                catch (FormatException ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
                }
                if (successBinding)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }
            return Task.CompletedTask;
        }
    }
}
