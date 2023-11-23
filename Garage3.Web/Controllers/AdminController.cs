using Garage3.Core.Entities;
using Garage3.Core.Models;
using Garage3.Persistence.Migrations;
using Garage3.Persistence.Services;
using Garage3.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;

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

        [HttpGet]
        public async Task<IActionResult> Index3()
        {
            var customers = await _garageService.GetCustomers();

            var model = new IndexViewModel2
            {
                Customers = customers,
            };

            return View("Customer",model);
        }

        [HttpGet]
        public async Task<IActionResult> Filter3(IndexViewModel2 viewModel)
        {
            var customers = await _garageService.GetCustomers();
            
            
            if (viewModel.FilterParams.Genre is null || viewModel.FilterParams.Title is null)
            {
                customers = customers;
            }
            else if (viewModel.FilterParams.Genre == "1")
            {
                customers = customers.Where(m => m.FirstName.StartsWith(viewModel.FilterParams.Title));
            }
            else
            {
                customers = customers.Where(m => m.LastName.StartsWith(viewModel.FilterParams.Title));
            }
                              
            var model = new IndexViewModel2
            {
                Customers = customers,
            };

            return View(nameof(Customer), model);
        }

        public IActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddType([Bind("Id,Type,Size")] VehicleType vehicleType)
        {
            

                var t = await _garageService.GetVehicleTypeByType(vehicleType.Type);
                if (t is null)
                {
                    if(await _garageService.AddVehicleType(vehicleType))
                    {
                        Feedback feedback = new Feedback() { status = "ok", message = "Vehicle Type added successfully." };
                        TempData["AlertMessage"] = JsonConvert.SerializeObject(feedback);
                        return View();
                    }
                    else
                    {
                        Feedback feedback = new Feedback() { status = "error", message = "Vehicle Type already exists." };
                        TempData["AlertMessage"] = JsonConvert.SerializeObject(feedback);
                        return View();
                    }
                    
                    
                }
                else
                {
                    Feedback feedback = new Feedback() { status = "error", message = "Vehicle Type already exists." };
                    TempData["AlertMessage"] = JsonConvert.SerializeObject(feedback);
                    return View();
                }
                // return Problem("");

            
        }

        public async Task<IActionResult> Sort(string sortOrder)
        {
            var customers = await _garageService.GetCustomers();

            if (String.IsNullOrEmpty(sortOrder)) ViewBag.FirstNameSortParm = "FirstName_desc";
            else
            {
                ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            }
            
            switch (sortOrder)
            {
                case "FirstName_desc":
                    customers = customers.OrderByDescending(s => s.FirstName[0]).ThenByDescending(y => y.FirstName[1]).ToList();
                    break;
                default:
                    customers = customers.OrderBy(s => s.FirstName[0]).ThenBy(y => y.FirstName[1]).ToList();
                    break;
            }

            var model1 = new IndexViewModel2
            {
                Customers = customers,
            };
            return View("Customer", model1);
            
            

            //Testing
        }


    }
}
