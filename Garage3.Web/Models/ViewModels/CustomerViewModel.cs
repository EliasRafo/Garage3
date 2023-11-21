using Garage3.Core.Entities;
using Garage3.Core.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class CustomerViewModel
    {
        // Property to hold information about the customer.
        public Customer Customer { get; set; }

        // Property to hold the calculated age of the customer.
        public int CustomerAge { get; set; }

        // Property to hold a list of parking spots associated with the customer.
        public List<ParkingSpot> ParkingSpots { get; set; }
    }
}
