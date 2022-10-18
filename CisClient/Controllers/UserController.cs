using CisClient.Src.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CisClient.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Authorize([FromForm] LoginModel model)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Alex")
            };
            var Identify=new ClaimsIdentity(Claims, "MyAuthCookie");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(Identify);
            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index","Bypass");
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
