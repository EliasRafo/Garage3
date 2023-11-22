using Garage3.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class OverviewViewModel
    
    {
        public string? Owner { get; set; }
        public string? MembershipType { get; set; }
        public string? VehicleType { get; set; }
        public string? RegNum { get; set; }
        public TimeSpan ParkDuration { get; set; }
    }
}
