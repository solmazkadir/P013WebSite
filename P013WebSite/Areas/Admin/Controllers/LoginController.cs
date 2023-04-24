﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;
using System.Security.Claims;

namespace P013WebSite.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email,string password)
        {
            try
            {
                var kullanici = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password && x.IsActive);
                if (kullanici == null)
                {
                    TempData["Mesaj"] = "Giriş Başarısız!";
                }
                else
                {
                    var haklar = new List<Claim>() //claim = hak
                    {
                        new Claim(ClaimTypes.Email,kullanici.Email) //giriş için hak tanımladık
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar,"Login"); //kullanıcıya kimlik tanımladık
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
        public IActionResult Logout()
        {
            return View();
        }
    }
}
