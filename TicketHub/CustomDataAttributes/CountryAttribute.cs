using System.ComponentModel.DataAnnotations;

namespace TicketHub.CustomDataAnnotations
{
    public class CountryAttribute : ValidationAttribute
    {
        public CountryAttribute()
        {
            ErrorMessage = "Invalid country. Only 'CA' (Canada) is accepted.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string country)
            {
                if (country.ToUpper() == "CA")
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }
            return new ValidationResult("Invalid country value.");
        }
    }
}

