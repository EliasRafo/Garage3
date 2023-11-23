using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Garage
    {
        public int Id { get; set; }

        //public int SpotId { get; set; }
        public string GarageName { get; set; }
        public int Capacity { get; set; }
        //public in BlockSize { get; set; }

        //Navigation property
        public ICollection<Spot> Spots { get; set; }

    }
}