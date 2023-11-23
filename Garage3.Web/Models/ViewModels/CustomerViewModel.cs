using Garage3.Core.Entities;
using Garage3.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;

namespace Garage3.Web.Models.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }

        public int CustomerAge { get; set; }

        public List<ParkingSpot> ParkingSpots { get; set; }

        public IEnumerable <SelectListItem> SelectListVihecles { get; set; }

        public Vehicle vehicle { get; set; }

        public int VehicleId { get; set; }

        public int Spotid { get; set; }


        //Customer and vehicle should be replaced by properties for the properties we use from the models(to exclude unused properties)
        //public string VehicleId;

        //OverviewVehicle overviewVehicle { get; set; }

        //public class OverviewVehicle
        //{
        //    public string RegNumber { get; set; }

        //    public int VehicleId { get; set; }

        //    public string VehicleType { get; set; }

        //    public int Brand { get; set; }

        //}
    }

}
