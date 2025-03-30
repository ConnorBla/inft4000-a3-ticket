using System.ComponentModel.DataAnnotations;

namespace TicketHub.CustomDataAnnotations
{
    public class AddressAttribute : ValidationAttribute
    {
        public AddressAttribute()
        {
            ErrorMessage = "Invalid address.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string address)
            {
                if (string.IsNullOrWhiteSpace(address))
                {
                    return new ValidationResult("Address cannot be empty.");
                }

                // Split the address into parts
                string[] addressParts = address.Split(' ');

                // Check if the first part is a number
                if (addressParts.Length < 2 || !int.TryParse(addressParts[0], out _))
                {
                    return new ValidationResult("Address format is (number) (street name[s]).");
                }

                // The rest is the street name
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
