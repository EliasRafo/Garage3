using Garage3.Core.Models;
using Garage3.Persistence.Data;
using Garage3.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Garage3.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly Garage3WebContext _context;

        public AdminController(Garage3WebContext context)
        {
            _context = context;
        }

        public IActionResult Overview()
        {
            var viewModel = new OverviewViewModel
            {
                Capacity = _context.Garages.FirstOrDefault()?.Capacity ?? 0,
                CustomerNumber = _context.Customers.Count(),
                VehiclesNumber = _context.Vehicles.Count(),
                CurrentlyParked = _context.Vehicles.Count(v => v.Parked),
                VehiclesStatistic = _context.Vehicles.GroupBy(v => v.GetType)
                                    .Select(group => new VehicleTypesDto
                                    {
                                        Type = group.Key,
                                        Count = group.Count()
                                    }).ToList(),
                ParkedVehicles = _context.Vehicles
                    .Where(v => v.Parked)
                    .Select(v => new ParkedVehicleViewModel
                    {
                        Brand = v.Brand,
                        Color = v.Color,
                        Model = v.Model,
                        RegNum = v.RegNum,
                        WheelsNumber = v.WheelsNumber
                    }).ToList()
            };

            return View(viewModel);
        }
    }
}