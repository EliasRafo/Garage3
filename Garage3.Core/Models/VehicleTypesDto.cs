using Garage3.Core.Entities;
namespace Garage3.Core.Models
{

   // public Spot? Spot { get; set; }
    public class ParkingSpot
    {
        public int Id { get; set; }
        public bool Reserved { get; set; }

    }
    public record VehicleTypesDto(string Name, int Total);

}
