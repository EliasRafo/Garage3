using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    // Represents the entity for a customer in the system.
    public class Customer
    {
        // Unique identifier for the customer.
        public int Id { get; set; }

        // Required field for the customer's first name.
        [Required]
        [DisplayName("First name")]
        [StringLength(10, MinimumLength = 3)] // Set maximum and minimum length constraints.
        public string FirstName { get; set; }

        // Required field for the customer's last name.
        [Required]
        [DisplayName("Last name")]
        [StringLength(15, MinimumLength = 3)] // Set maximum and minimum length constraints.
        public string LastName { get; set; }

        // Display-only property representing the full name of the customer.
        [DisplayName("Full name")]
        public string FullName => $"{FirstName} {LastName}";

        // Required field for the customer's Social Security Number.
        [Required]
        [RegularExpression(@"^(19|20)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])[-]\d{4}$",
            ErrorMessage = "Social Security Number must be in this format YYYYMMDD-NNNN")]
        public string SocialNum { get; set; }

        // Navigation property representing the collection of vehicles associated with the customer.
        public ICollection<Vehicle> Vehicles { get; set; }
        public object Membership { get; set; }
        public string Name { get; set; }
    }
}
