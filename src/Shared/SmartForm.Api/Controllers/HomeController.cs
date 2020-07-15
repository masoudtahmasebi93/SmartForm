using Microsoft.AspNetCore.Mvc;

namespace SmartForm.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Hello from Actio API!");
        }
    }
}