using Garage3.Core.Entities;
using Garage3.Persistence.Services;
using Garage3.Web.Models;
using Garage3.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Garage3.Web.Controllers
{
    public class HomeController : Controller
    {
        // Private fields to store the logger and the garage service.
        private readonly ILogger<HomeController> _logger;
        private readonly IGarageService _garageService;

        // Constructor that injects the logger and the garage service.
        public HomeController(ILogger<HomeController> logger, IGarageService garageService)
        {
            _logger = logger;
            _garageService = garageService;
        }

        // Action method for the home page.
        public async Task<IActionResult> Index()
        {
            // Create a new instance of the OverviewViewModel.
            OverviewViewModel overviewViewModel = new OverviewViewModel();

            // Set the capacity property of the view model using the garage service.
            overviewViewModel.Capacity = await _garageService.GetCapacity();

            // Set the VehiclesStatistic property of the view model using the garage service.
            overviewViewModel.VehiclesStatistic = await _garageService.GetVehicleTypes();

            // Set the CustomerNumber property of the view model using the garage service.
            overviewViewModel.CustomerNumber = await _garageService.GetCustomerNumber();

            // Set the VehiclesNumber property of the view model using the garage service.
            overviewViewModel.VehiclesNumber = await _garageService.GetVehiclesNumber();

            // Set the CurrentlyParked property of the view model using the garage service.
            overviewViewModel.CurrentlyParked = await _garageService.GetCurrentlyParked();

            // Return the Index view with the populated view model.
            return View(nameof(Index), overviewViewModel);
        }

        // Action method for handling search requests.
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string ssnumber)
        {
            // Validate the input Social Security Number using a regular expression.
            if (Regex.IsMatch(ssnumber, @"^(19|20)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])[-]\d{4}$"
))
            {
                // Check if a member with the provided Social Security Number exists.
                var member = await _garageService.IsMember(ssnumber);

                if (member is not null)
                {
                    // Redirect to the Index action of the Member controller with the member data.
                    return RedirectToAction("Index", "Member", member);
                }
            }

            // If no member is found or if SSN is invalid, return the Index view.
            return View("Index");
        }

        // Action method for displaying the Privacy view.
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method for handling errors.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Return the Error view with information about the error.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}