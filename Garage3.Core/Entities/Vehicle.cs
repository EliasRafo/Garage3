using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
       // public int CustomerId { get; set; }
       public int ParkingId { get; set; }
        public VehicleType VehicleType { get; set; }

        public string RegNum { get; set; }

        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int  WheelsNum { get; set; }
    }
}
