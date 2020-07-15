using Microsoft.AspNetCore.Mvc;

namespace SmartForm.Services.Activities.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Hello from SmartForm.Services.Reports API!");
        }
    }
}