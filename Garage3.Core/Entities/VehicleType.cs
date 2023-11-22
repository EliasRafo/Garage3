using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }

        //Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
