using Gorev7P013.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gorev7P013.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var data = new List<Slider>();
            return View();
        }
    }
}
