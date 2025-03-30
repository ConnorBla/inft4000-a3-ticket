using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicketHub.CustomDataAnnotations
{
    public class PostalCodeAttribute : ValidationAttribute
    {
        public PostalCodeAttribute()
        {
            ErrorMessage = "Invalid postal code.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string postalCode)
            {
                if (string.IsNullOrWhiteSpace(postalCode))
                {
                    return new ValidationResult("Postal code cannot be empty.");
                }

                // Define a regular expression for a valid postal code format
                var regex = new Regex(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$");

                if (!regex.IsMatch(postalCode))
                {
                    return new ValidationResult("Postal code format is invalid.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
