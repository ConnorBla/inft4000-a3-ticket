using System.ComponentModel.DataAnnotations;

namespace TicketHub.CustomDataAnnotations
{
    public class QuantityAttribute : ValidationAttribute
    {
        public QuantityAttribute()
        {
            ErrorMessage = "Quantity must be at least 1.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int quantity)
            {
                if (quantity >= 1)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }
            return new ValidationResult("Invalid quantity value.");
        }
    }
}


