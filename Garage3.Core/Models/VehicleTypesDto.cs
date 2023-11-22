namespace Garage3.Core.Models

{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public bool Reserved { get; set; }

        public Spot? Spot { get; set; }
    }
}
