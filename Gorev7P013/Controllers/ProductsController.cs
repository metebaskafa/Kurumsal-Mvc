using Gorev7P013.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorev7P013.Controllers
{
    public class ProductsController : Controller
       
    {
        private readonly DatabaseContext _databaseContext;
        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

       public async Task<IActionResult> IndexAsync()
        {
            var products = await _databaseContext.Products.Where(p => p.IsActive).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Search(string q)
        {
            var products = await _databaseContext.Products.Where(p => p.Name.Contains(q)).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> DetailAsync(int? id)
        {
            if (id is null) // EĞER ADRES ÇUBUĞUNDAN İD GÖNDERİLMEMİŞSE 
            {
                return BadRequest(); // ekrana geçersiz istek hatası ver
            }
            var product = await _databaseContext.Products.Include("Category").FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
