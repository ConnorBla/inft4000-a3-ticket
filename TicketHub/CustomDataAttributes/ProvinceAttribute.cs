using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TicketHub.CustomDataAnnotations
{
    public class ProvinceAttribute : ValidationAttribute
    {
        private static readonly HashSet<string> ValidProvinceCodes = new HashSet<string>
        {
            "AB", "BC", "MB", "NB", "NL", "NS", "NT", "NU", "ON", "PE", "QC", "SK", "YT"
        };

        public ProvinceAttribute()
        {
            ErrorMessage = "Invalid province.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string province)
            {
                if (string.IsNullOrWhiteSpace(province))
                {
                    return new ValidationResult("Province cannot be empty.");
                }

                // Check if the province code is valid
                if (!ValidProvinceCodes.Contains(province.ToUpper()))
                {
                    return new ValidationResult("Province code is invalid. Use a valid Canadian 2-letter province code.");
                }

                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}

