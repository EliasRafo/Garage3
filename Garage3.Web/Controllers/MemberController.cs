using Garage3.Core.Entities;
using Garage3.Core.Models;
using Garage3.Persistence.Services;
using Garage3.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage3.Web.Controllers
{
    public class MemberController : Controller
    {
        // Private field to store the garage service.
        private readonly IGarageService _service;

        // Constructor that injects the garage service.
        public MemberController(IGarageService service)
        {
            _service = service;
        }

        // Action method for displaying the member's details.
        public async Task<IActionResult> Index(Customer customer)
        {
            // Create a new instance of the CustomerViewModel.
            CustomerViewModel customerViewModel = new CustomerViewModel();

            // Get today's date.
            var today = DateTime.Today;

            // Extract the birth year from the Social Security Number.
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

            // Calculate the customer's age.
            customerViewModel.CustomerAge = today.Year - year;

            // Set the Customer property of the view model.
            customerViewModel.Customer = customer;

            // Get a list of parking spots and the garage capacity.
            List<Spot> spot = (List<Spot>)await _service.GetSpot();
            int Capacity = await _service.GetCapacity();

            // Get the parking spaces for display in the view.
            customerViewModel.ParkingSpots = GetParkingSpaces(spot, Capacity);

            // Return the Index view with the populated view model.
            return View(customerViewModel);
        }

        // Helper method to get a list of parking spaces.
        public List<ParkingSpot> GetParkingSpaces(List<Spot> s, int Capacity)
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

            for (int i = 1; i <= Capacity; i++)
            {
                // Check if there is a vehicle parked at the current spot.
                var v = s.Where(e => e.Address == i).FirstOrDefault();

                // Create a ParkingSpot object based on the availability of the spot.
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

                // Add the parking spot to the list.
                parkingSpots.Add(parkingSpot);
            }

            return parkingSpots;
        }

        // Action method for displaying the AddVehicle view.
        public async Task<IActionResult> AddVehicle(Customer customer)
        {
            // Pass necessary data to the AddVehicle view.
            ViewBag.customerId = customer.Id.ToString();
            ViewBag.types = await _service.GetTypes();
            return View("AddVehicle");
        }

        // Action method for handling the form submission to add a new vehicle.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(IFormCollection form)
        {
            // Check if the form submission is valid.
            if (ModelState.IsValid)
            {
                // Extract data from the form.
                int selectedId = Convert.ToInt32(form["VehicleType"]);
                var type = await _service.GetTypes();

                // Create a new Vehicle object based on the form data.
                Vehicle vehicle = new Vehicle()
                {
                    VehicleType = type.ElementAt(selectedId - 1),
                    RegNum = form["RegNum"],
                    Color = form["Color"],
                    Brand = form["Brand"],
                    Model = form["Model"],
                    WheelsNumber = Convert.ToInt32(form["WheelsNumber"]),
                    CustomerId = Convert.ToInt32(form["CustomerId"])
                };

                // Try to add the vehicle using the garage service.
                if (await _service.AddVehicle(vehicle))
                    return View("Index");
            }

            // If the form is not valid, return to the AddVehicle view.
            return View("AddVehicle");
        }
    }
}
