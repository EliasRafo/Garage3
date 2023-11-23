using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Spot
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public int Address { get; set; }

        // Foreign Key
        public int GarageId { get; set; }

        // Navigation property
        public Garage Garage { get; set; }

        // Foreign Key
        public int? VehicleId { get; set; }

        // Navigation property
        public Vehicle Vehicle { get; set; }
    }
}