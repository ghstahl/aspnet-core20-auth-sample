using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var identity = new ClaimsIdentity("MyCookieAuthenticationScheme");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Id));
            await HttpContext.SignInAsync("MyCookieAuthenticationScheme", new ClaimsPrincipal(identity));
            return Redirect("/");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuthenticationScheme");
            return Redirect("/");
        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
