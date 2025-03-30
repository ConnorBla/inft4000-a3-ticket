using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicketHub.CustomDataAnnotations
{
    public class CityAttribute : ValidationAttribute
    {
        public CityAttribute()
        {
            ErrorMessage = "Invalid city.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string city)
            {
                if (string.IsNullOrWhiteSpace(city))
                {
                    return new ValidationResult("City cannot be empty.");
                }

                // Define a regular expression for a valid city name format
                var regex = new Regex(@"^[A-Za-z\s\-]+$");

                if (!regex.IsMatch(city))
                {
                    return new ValidationResult("City format is invalid.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}

