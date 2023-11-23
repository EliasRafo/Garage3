﻿using Garage3.Core.Entities;
using Garage3.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class OverviewViewModel
    {
        public int Capacity { get; set; }

        public int CustomerNumber { get; set; }

        public int VehiclesNumber { get; set; }

        public int CurrentlyParked { get; set; }

        public List<VehicleTypesDto> VehiclesStatistic { get; set; }
        public string Owner { get; internal set; }
        public string VehicleType { get; internal set; }
        public string RegNum { get; internal set; }
        public TimeSpan ParkDuration { get; internal set; }
    }
}
