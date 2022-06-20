using Microsoft.AspNetCore.Mvc;
using SmartTeapotsWebProject.Data.Interfaces;

namespace SmartTeapotsWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllSmartTeapots _smartTeapots;

        public HomeController(IAllSmartTeapots smartTeapots)
        {
            _smartTeapots = smartTeapots;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Product List";

            var smartTeapots = _smartTeapots.SmartTeapots;
            return View(smartTeapots);
        }
    }
}
