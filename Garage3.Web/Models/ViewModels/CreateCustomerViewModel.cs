using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class CreateCustomerViewModel
    {

      
            [Required]
            [DisplayName("First name")]
            [StringLength(10, MinimumLength = 3)]
            public string FirstName { get; set; }

            [Required]
            [DisplayName("Last name")]
            [StringLength(15, MinimumLength = 3)]
            public string LastName { get; set; }


            [Required]
            [RegularExpression(@"^(19|20)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])[-]\d{4}$",
                ErrorMessage = "Social Security Number must be in this format YYYYMMDD-NNNN")]
            public string SocialNum { get; set; }

    }

}
