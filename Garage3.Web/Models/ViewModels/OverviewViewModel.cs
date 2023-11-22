using Garage3.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class OverviewViewModel

        public int CustomerNumber { get; set; }

        public int VehiclesNumber { get; set; }

        public int CurrentlyParked { get; set; }
        public List<VehicleTypesDto> VehiclesStatistic { get; set; }

    }
}
