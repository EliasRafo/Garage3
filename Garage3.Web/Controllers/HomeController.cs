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
        private readonly ILogger<HomeController> _logger;
        private readonly IGarageService _garageService;

        public HomeController(ILogger<HomeController> logger, IGarageService garageService)
        {
            _logger = logger;
            _garageService = garageService;
        }

        public async Task<IActionResult> Index()
        {
            OverviewViewModel overviewViewModel = new OverviewViewModel();

            
            overviewViewModel.Capacity = await _garageService.GetCapacity();
            
            overviewViewModel.VehiclesStatistic = await _garageService.GetVehicleTypes();
            overviewViewModel.CustomerNumber = await _garageService.GetCustomerNumber();

            overviewViewModel.VehiclesNumber = await _garageService.GetVehiclesNumber();

            overviewViewModel.CurrentlyParked = await _garageService.GetCurrentlyParked();

            return View(nameof(Index), overviewViewModel);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string ssnumber)
        {
           // if (Regex.IsMatch(searchField, @"^(19|20)?[0-9]{2}[0-9]{2}(0?[1-9]|1[012])(0[1-9]|[12]\d|3[01])[-]? [0-9]{4}$"))  
            {
                var member = await _garageService.IsMember(ssnumber);
                if (member is not null)
                {
                                        
                    return RedirectToAction("Index", "Member", member);
                }
            }

            return View("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}