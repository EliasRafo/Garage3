using Garage3.Core.Models;
using System.Collections.Generic;

namespace Garage3.Web.Models.ViewModels
{
    public class OverviewViewModel
    {
        public int Capacity { get; set; }
        public int CustomerNumber { get; set; }
        public int VehiclesNumber { get; set; }
        public int CurrentlyParked { get; set; }
        public required List<VehicleTypesDto> VehiclesStatistic { get; set; }
        public required List<ParkedVehicleViewModel> ParkedVehicles { get; set; }
    }

    public class ParkedVehicleViewModel
    {
        public required string Brand { get; set; }
        public required string Color { get; set; }
        public required string Model { get; set; }
        public required string RegNum { get; set; }
        public int WheelsNumber { get; set; }
    }
}