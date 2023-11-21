using Garage3.Core.Entities;
using Garage3.Core.Models;
using Garage3.Persistence.Services;
using Garage3.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage3.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IGarageService _service;
        public MemberController(IGarageService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Back(int? id)
        {
            Customer customer = await _service.GetCustomerByID((int)id);
            CustomerViewModel customerViewModel = await CreateCustomerViewModel(customer);

            return View(nameof(Index), customerViewModel);
        }
        public async Task<IActionResult> Index(Customer customer)
        {
            CustomerViewModel customerViewModel = await CreateCustomerViewModel(customer);
            
            return View(customerViewModel);
            
        }

        private async Task<CustomerViewModel> CreateCustomerViewModel(Customer customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            var today = DateTime.Today;

            int year;

            var Birthday = customer.SocialNum.Split(' ')[0];

            if (Birthday.Length == 8)
            {
                year = Int32.Parse(Birthday.Substring(0, 4));
            }
            else
            {
                year = Int32.Parse(Birthday.Substring(0, 2));
            }

            // Calculate the age.
            customerViewModel.CustomerAge = today.Year - year;

            customerViewModel.Customer = customer;

            List<Spot> spot = (List<Spot>)await _service.GetSpot();
            int Capacity = await _service.GetCapacity();

            customerViewModel.ParkingSpots = GetParkingSpaces(spot, Capacity);

            return customerViewModel;
        }

        public List<ParkingSpot> GetParkingSpaces(List<Spot> s, int Capacity)
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

            for (int i = 1; i <= Capacity; i++)
            {
                var v = s.Where(e => e.Address == i).FirstOrDefault();
                ParkingSpot parkingSpot = new ParkingSpot();

                if (v is null)
                {
                    parkingSpot.Id = i;
                    parkingSpot.Reserved = false;
                    parkingSpot.Spot = null;
                }
                else
                {
                    parkingSpot.Id = i;
                    parkingSpot.Reserved = true;
                    parkingSpot.Spot = v;
                }
                parkingSpots.Add(parkingSpot);
            }

            return parkingSpots;
        }

        
        public async Task<IActionResult> AddVehicle(int id)
        {
            ViewBag.customerId = id.ToString();
            ViewBag.types = await _service.GetTypes(); ;
            return View("AddVehicle");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                int selectedId = Convert.ToInt32(form["VehicleType"]);
                 var type = await _service.GetTypes();

                int id = Convert.ToInt32(form["CustomerId"]);
                string reg = form["RegNum"];

                
                    Vehicle vehicle = new Vehicle()
                    {

                        VehicleType = type.Where(t => t.Id == selectedId).FirstOrDefault(),
                        RegNum = form["RegNum"],
                        Color = form["Color"],
                        Brand = form["Brand"],
                        Model = form["Model"],
                        WheelsNumber = Convert.ToInt32(form["WheelsNumber"]),

                        CustomerId = id
                    };

                    if (await _service.AddVehicle(vehicle))
                    {
                        Customer customer = await _service.GetCustomerByID(id);
                        CustomerViewModel customerViewModel = await CreateCustomerViewModel(customer);
                        return View("Index", customerViewModel);
                    }

                    else
                {
                    Customer customer = await _service.GetCustomerByID(id);
                    CustomerViewModel customerViewModel = await CreateCustomerViewModel(customer);
                    return View("Index", customerViewModel);
                }


            }
            return View("AddVehicle");
        }

        public async Task<IActionResult> CheckOut(int id)
        {
            if (id == null)
            {
                
                return View("Index");
            }

            var spot = await _service.GetSpotByID(id);
            if (spot == null)
            {
                
                return View("Index");
            }

            return View(spot);
        }

        [HttpPost, ActionName("CheckOut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOutConfirmed(int id)
        {

            var spot = await _service.GetSpotByID(id);
            if (spot != null)
            {
                
                DateTime CheckOut = DateTime.Now;

                Spot s = new Spot()
                {
                    Id = id,
                    Active = false,
                    CheckIn = spot.CheckIn,
                    CheckOut = CheckOut,
                    Address = spot.Address,
                    GarageId = spot.GarageId,
                    VehicleId = spot.VehicleId
                };

                _service.UpdateSpot(s);

    TimeSpan duration = CheckOut - spot.CheckIn;

                var pr = Math.Floor(duration.TotalMinutes * 1) + 20;

                var model = new ReceiptViewModel()
                {
                    Spot = spot,
                    CheckOutTime = CheckOut,
                    ParkingPeriod = $"{duration.Days} Days, {duration.Hours} Hours, {duration.Minutes} Minutes",
                    Price = $"{pr} SEK"
                };

                return View("Receipt", model);
            }

        [HttpGet]
        public IActionResult Park(Vehicle vehicle)//Park() TEST
        {
            //TEST
            var a=vehicle;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park(Vehicle vehicle, int id)
        {
            //vehicle.Spots.
            //vehicle.ParkingTime = DateTime.Now;
            //vehicle.Address = id;
            var test = vehicle;
            if (ModelState.IsValid)
            {
                if (!await _service.VehicleExists(vehicle))
                {
                    await _service.AddVehicle(vehicle);
                    //await _context.SaveChangesAsync();
                    //Feedback feedback = new Feedback() { status = "ok", message = $"Vihecle with registration number {vehicle.RegNum} is now parked at spot {id}." };
                    //TempData["AlertMessage"] = JsonConvert.SerializeObject(feedback);

                    return RedirectToAction(nameof(Index), "Overview");
                }
                else
                {
                    //Feedback feedback = new Feedback() { status = "ok", message = $"Vehicle with registration number {vehicle.RegNum} already exist in the garage." };
                    //TempData["AlertMessage"] = JsonConvert.SerializeObject(feedback);
                }

            }

            return View(vehicle);
        }


            return RedirectToAction(nameof(Index));
        }

    }
}
