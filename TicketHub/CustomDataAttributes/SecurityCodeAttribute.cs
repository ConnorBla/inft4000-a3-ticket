using System.ComponentModel.DataAnnotations;

namespace TicketHub.CustomDataAnnotations
{
    public class SecurityCodeAttribute : ValidationAttribute
    {
        public SecurityCodeAttribute()
        {
            ErrorMessage = "Invalid security code.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string securityCode)
            {
                if ((securityCode.Length == 3 || securityCode.Length == 4) && int.TryParse(securityCode, out _))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Security code must be 3 or 4 digits.");
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}


