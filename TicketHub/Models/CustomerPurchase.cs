using System.ComponentModel.DataAnnotations;
using TicketHub.CustomDataAnnotations;

namespace TicketHub.Models
{
    public class CustomerPurchase
    {
        [Required]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Quantity]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        [CreditCard]
        public string CreditCard { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        [ExpirationDate]
        public string Expiration { get; set; }

        [Required(ErrorMessage = "Security code is required.")]
        [SecurityCode]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Address]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [City]
        public string City { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        [Province]
        public string Province { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [PostalCode]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [Country]
        public string Country { get; set; }
    }
}
