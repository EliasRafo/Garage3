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
        public int Id { get; set; }
        public bool Reserved { get; set; }

        public Spot? Spot { get; set; }
    }
}
