using Garage3.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Web.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public Spot Spot { get; set; }

        [Display(Name = "Checked out")]
        public DateTime CheckOutTime { get; set; }

        [Display(Name = "Duration")]
        public string ParkingPeriod { get; set; }
        [Display(Name = "Price")]
        public string Price { get; set; }
    }
}
