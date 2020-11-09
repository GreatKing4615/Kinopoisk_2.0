using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kinopoisk.Domain.Core;
using Kinopoisk.Infrastructure.Data.Base;
using Kinopoisk.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Kinopoisk.Domain.Interfaces;
using Kinopoisk.Infrastructure.Data;

namespace Kinopoisk.Controllers
{
    public class AccountController : Controller
    {

        UnitOfWork unitOfWork;

        public AccountController(KinopoiskDbContext dbContext)
        {
            unitOfWork = new UnitOfWork(dbContext);
        }

       
        

        [HttpGet]
        [Route("/account/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = unitOfWork.SQLPerson.Chek(model.Login,model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = unitOfWork.SQLPerson.GetPerson( model.Login);
                if (user == null)
                {

                    unitOfWork.SQLPerson.Add(user);
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
