using Gorev7P013.Data;
using Gorev7P013.Entities;
using Gorev7P013.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorev7P013.Controllers
{

    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public CategoriesController(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            var data = new List<Slider>();
            return View();
        }
        public IActionResult Index(int? id) 
        {
            if (id is null)
            {
                return BadRequest();

            }
            var category  = _databaseContext.Categories.Include(p=>p.Products).FirstOrDefault(c=>c.Id== id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }
    }
}
