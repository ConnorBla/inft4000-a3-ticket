using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TicketHub.CustomDataAnnotations
{
    public class ExpirationDateAttribute : ValidationAttribute
    {
        public ExpirationDateAttribute()
        {
            ErrorMessage = "Invalid expiration date.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string expirationDate)
            {
                if (DateTime.TryParseExact(expirationDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    //make sure the expiration date is the last day of the month
                    date = date.AddMonths(1).AddDays(-1);

                    if (date >= DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Expiration date cannot be in the past.");
                    }
                }
                else
                {
                    return new ValidationResult("Expiration date format is invalid. Use MM/YY.");
                }
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}


