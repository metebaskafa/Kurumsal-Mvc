using Gorev7P013.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gorev7P013.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new List<Slider>() {
            new Slider() { Id = 1, Image = "/Image/B.jpg" },
            new Slider() { Id = 2, Image = "/Image/B2.jpg" },
            new Slider() { Id = 3, Image = "/Image/B3.jpg",        },
            };
            return View(model);
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