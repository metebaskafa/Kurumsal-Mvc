using Gorev7P013.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Gorev7P013.Entities;

namespace Gorev7P013.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public LoginController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var kullanici = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.IsActive);
                if (kullanici == null)
                {
                    TempData["Mesaj"] = "<div class='alert alert-danger'>  Giriş Başarısız!</div>";
                }
                else
                {
                    var haklar = new List<Claim>() // claim = hak
                    {
                        new Claim(ClaimTypes.Email, kullanici.Email) // giriş için hak tanımladık
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcıya kimlik tanımladık
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (kullanici.IsAdmin)
                    {
                        return Redirect("/Admin");
                    }
                    else
                    {
                        return Redirect("/Home");
                    }
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }
        [Route("Logout")] // adres çubuğundan yaptığımız yönlendirmede login/logout yerine sadece logout a gidince çıkış yapsın.
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
    }
}
