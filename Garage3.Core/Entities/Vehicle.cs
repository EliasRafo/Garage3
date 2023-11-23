using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Vehicle
    {
        public object Type;

        //[Key]
        public int Id { get; set; }
        //public int ParkingId { get; set; }
        //FK
        
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Registration number")]
        [RegularExpression(@"^[a-zA-Z]{3}[0-9]{3}$", ErrorMessage = "The registration number should be in this form ABC123.")]
        [Required(ErrorMessage = "Registration number is required")]
        [StringLength(6)]
        public string RegNum { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Color is required")]
        [StringLength(30)]
        public string Color { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is required")]
        [StringLength(30)]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Model is required")]
        [StringLength(30)]
        public string Model { get; set; }

        [Display(Name = "Wheels Number")]
        [Required(ErrorMessage = "Wheels Number is required")]
        [Range(0, 12)]
        public int WheelsNumber { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }

        // Navigation property
        public ICollection<Spot> Spots { get; set; }
    }

}