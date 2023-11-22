using Garage3.Core.Models;
using Garage3.Persistence.Data;
using Garage3.Web.Models.ViewModels;
using Garage3.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly Garage3WebContext _context;
        private readonly IGarageService _garageService;

        public AdminController(Garage3WebContext context)
        public AdminController(IGarageService garageService)
        {
            _context = context;
            _garageService = garageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        public async Task<IActionResult> Customer()
        {
            var viewModel = new OverviewViewModel
            return View(await _garageService.GetCustomers());
        }

        public async Task<IActionResult> Details(int? id)
        {
                Capacity = _context.Garages.FirstOrDefault()?.Capacity ?? 0,
                CustomerNumber = _context.Customers.Count(),
                VehiclesNumber = _context.Vehicles.Count(),
                CurrentlyParked = _context.Vehicles.Count(v => v.Parked),
                VehiclesStatistic = _context.Vehicles.GroupBy(v => v.GetType)
                                    .Select(group => new VehicleTypesDto
            if (id == null)
            {
                                        Type = group.Key,
                                        Count = group.Count()
                                    }).ToList(),
                ParkedVehicles = _context.Vehicles
                    .Where(v => v.Parked)
                    .Select(v => new ParkedVehicleViewModel
                return NotFound();
            }

            var vehicles = await _garageService.GetVehiclesByCustomerId((int)id);
            if (vehicles == null)
            {
                        Brand = v.Brand,
                        Color = v.Color,
                        Model = v.Model,
                        RegNum = v.RegNum,
                        WheelsNumber = v.WheelsNumber
                    }).ToList()
            };
                return NotFound();
            }

            return View(viewModel);
            return View(vehicles);
        }
    }
}
