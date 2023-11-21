using Garage3.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class OverviewViewModel
    {
        // Property to hold the capacity of the garage.
        public int Capacity { get; set; }

        // Property to hold the number of customers.
        public int CustomerNumber { get; set; }

        // Property to hold the total number of vehicles.
        public int VehiclesNumber { get; set; }

        // Property to hold the number of currently parked vehicles.
        public int CurrentlyParked { get; set; }

        // Property to hold a list of vehicle types and their counts.
        public List<VehicleTypesDto> VehiclesStatistic { get; set; }
    }
}
