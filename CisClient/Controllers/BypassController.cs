﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CisClient.Controllers
{
    [Route("bypass")]
    [ApiController]
    [Authorize]
    public class BypassController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
