using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Vehicle
    {
        //[Key]
        public int Id { get; set; }
        //public int ParkingId { get; set; }
        // FK
        public VehicleType VehicleType { get; set; }

        public string RegNum { get; set; }

        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WheelsNumber { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }

        // Navigation property
        public ICollection<Spot> Spots { get; set; }
    }

}
