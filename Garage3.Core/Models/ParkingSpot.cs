using Garage3.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Models
{
    public class ParkingSpot
    {
        // The unique identifier for the parking spot.
        public int Id { get; set; }

        // Indicates whether the parking spot is reserved or not.
        public bool Reserved { get; set; }

        // Navigation property representing the relationship between ParkingSpot and Spot entities.
        // This property allows navigation from a ParkingSpot to the Spot associated with that parking spot.
        // Note: The use of '?' after Spot indicates that the Spot property can be nullable (i.e., it can be assigned a value of null).
        public Spot? Spot { get; set; }
    }
}
