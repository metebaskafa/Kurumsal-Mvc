using Microsoft.AspNetCore.Mvc;

namespace Gorev7P013.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
