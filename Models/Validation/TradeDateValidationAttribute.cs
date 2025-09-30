using System.ComponentModel.DataAnnotations;

namespace MyTradePrototype.Models.Validation
{
    // Custom Validation Attribute
    public class TradeDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime tradeDate)
            {
                if (tradeDate.Date < DateTime.Today)
                {
                    return new ValidationResult(ErrorMessage ?? "Trade date cannot be in the past.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
