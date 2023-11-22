using Garage3.Web.Models.ViewModels;
using Garage3.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
            var customers = await _garageService.GetCustomers();
            return View(customers);
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

        public async Task<IActionResult> Overview(int customerId)
        {
            var customer = await _garageService.GetCustomerByID(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            var vehicles = await _garageService.GetVehiclesByCustomerId(customerId);
            var vehicle = vehicles.FirstOrDefault();

            var viewModel = new OverviewViewModel
            {
                Owner = customer.Name,
                MembershipType = customer.Membership.Type,
                VehicleType = vehicle.Type.Name,
                RegNum = vehicle.RegistrationNumber,
                ParkDuration = TimeSpan.FromHours(1)
            };

            return View(viewModel);
        }
    }
}