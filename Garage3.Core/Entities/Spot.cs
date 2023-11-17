using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Spot
    {
        public int Id { get; set; }
        public bool Reserved { get; set; }
        //public int SizeOccupied { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        // Foreign Key
        public int GarageId { get; set; }

        //Navigation property
        public Garage Garage { get; set; }

        // Foreign Key
        public int VehicleId { get; set; }

        //Navigation property
        public Vehicle Vehicle { get; set; }
    }
}
