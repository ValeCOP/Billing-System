namespace Billing_System.Core.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;

    public class DateComparisonAttribute : ValidationAttribute
    {
        private readonly string _activationData;

        public DateComparisonAttribute(string activationDate)
        {
            _activationData = activationDate;
        }

        protected override ValidationResult? IsValid(object? expiredDate, ValidationContext validationContext)
        {
            var earlierPropertyInfo = validationContext.ObjectType.GetProperty(_activationData);

            if (earlierPropertyInfo == null)
            {
                return new ValidationResult($"Invalid property name: {_activationData}");
            }


            var earlierDateValue = (DateTime)earlierPropertyInfo.GetValue(validationContext.ObjectInstance)!;
            var laterDateValue = (DateTime)expiredDate!;

            if (laterDateValue <= earlierDateValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
