using Gorev7P013.Data;
using Gorev7P013.Entities;
using Gorev7P013.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Gorev7P013.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _databaseContext.Sliders.ToListAsync(),
                Products = await _databaseContext.Products.Where(p => p.IsActive && p.IsHome).ToListAsync(),
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactUsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _databaseContext.AddAsync(contact);
                    await _databaseContext.SaveChangesAsync();
                    TempData["Mesaj"] = "<div class'alert alert-success'>Mesajınız Gönderildi..Teşekkürler.. </div>";
                    return RedirectToAction("ContactUs");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}