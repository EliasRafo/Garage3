namespace Garage3.Core.Models

using Garage3.Core.Entities;
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public bool Reserved { get; set; }

namespace Garage3.Core.Models
{
    public record VehicleTypesDto(string Name, int Total);
        public Spot? Spot { get; set; }
    }
}
