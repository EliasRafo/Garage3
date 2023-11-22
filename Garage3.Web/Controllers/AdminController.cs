using Garage3.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGarageService _garageService;

        public AdminController(IGarageService garageService)
        {
            _garageService = garageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Customer()
        {
            return View(await _garageService.GetCustomers());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _garageService.GetVehiclesByCustomerId((int)id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }
    }
}
