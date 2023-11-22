using Garage3.Core.Entities;

namespace Garage3.Core.Models
{
    public class ParkVihecle
    {
        public bool Active { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public int Address { get; set; }

        // Foreign Key
        public int? VehicleId { get; set; }

    }
}

