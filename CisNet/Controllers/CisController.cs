using CisNet.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CisNet.Controllers
{
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/cis")]
    [ApiController]
    public class CisController : Controller
    {
        private readonly ILogger<CisController> _logger;
        private ModelDb _model;

        public CisController(ILogger<CisController> logger)
        {
            _logger = logger;
            _model = new ModelDb();
        }

        [Route("index")]
        public IActionResult Index()
        {
            ViewData["Text"] = "Пробный текст";
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("archive")]
        public IActionResult Archive()
        {
            return View();
        }

        [Route("login")]
        [HttpGet("Login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"]=returnUrl;
            return View();
        }

        [Route("login")]
        [HttpPost("Login")]
        public async Task<IActionResult> Validate(string Username, string Password, string ReturnUrl)
        {
            if (_model.CheckUser(Username,Password))
            {
                var claims=new List<Claim>();
                claims.Add(new Claim("Username",Username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Username));
                var claimsIdentyty=new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentyty));
                return Redirect(ReturnUrl);
            }
            ViewData["returnUrl"] = ReturnUrl;
            TempData["Error"] = "Ошибка! Пользователь не определен или ошибка при вводе пароля!";
            return View("login");
        }

        [Authorize]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
