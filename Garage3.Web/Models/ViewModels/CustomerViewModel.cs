using Garage3.Core.Entities;
using Garage3.Core.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
            
        public int CustomerAge { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }
    }
}
