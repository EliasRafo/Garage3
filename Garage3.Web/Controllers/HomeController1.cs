using Microsoft.AspNetCore.Mvc;

namespace Garage3.Web.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
