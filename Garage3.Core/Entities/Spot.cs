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
        public int GarageId { get; set; }
        public bool Reserved { get; set; }
        //public int SizeOccupied { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
