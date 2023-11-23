using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First name")]
        [StringLength(10, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last name")]
        [StringLength(15, MinimumLength = 3)]
        public string LastName { get; set; }

        [DisplayName("Full name")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [RegularExpression(@"^(19|20)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])[-]\d{4}$",
            ErrorMessage = "Social Security Number must be in this format YYYYMMDD-NNNN")]
        public string SocialNum { get; set; }

        //Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}