using Microsoft.AspNetCore.Mvc;

namespace CisClient.Controllers
{
    [Route("bypass")]
    [ApiController]
    public class BypassController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
