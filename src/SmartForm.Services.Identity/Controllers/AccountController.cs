using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using SmartForm.Services.Identity.Services;

namespace SmartForm.Services.Identity.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IBusClient busClient)
        {
            _busClient = busClient;
            _userService = userService;
        }

        /// <summary>
        ///     This is for creating Users
        ///     This uses CreateUser command
        /// </summary>
        /// <returns>accepted</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await _busClient.PublishAsync(command);

            return Accepted();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
        {
            return Json(await _userService.LoginAsync(command.Email, command.Password));
        }

        [HttpGet("LoginAuth")]
        public async Task Login(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties {RedirectUri = returnUrl});
        }

        // [Authorize]
        // public async Task Logout()
        // {
        //     await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
        //     {
        //         // Indicate here where Auth0 should redirect the user after a logout.
        //         // Note that the resulting absolute Uri must be whitelisted in the 
        //         // **Allowed Logout URLs** settings for the client.
        //         RedirectUri = Url.Action("Get", "Home")
        //     });
        //     await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        // }

        /// <summary>
        ///     This is just a helper action to enable you to easily see all claims related to a user. It helps when debugging your
        ///     application to see the in claims populated from the Auth0 ID Token
        /// </summary>
        /// <returns></returns>
        // [Authorize]
        // public IActionResult Claims()
        // {
        //     return View($"");
        // }
        //
        // public IActionResult AccessDenied()
        // {
        //     return View($"");
        // }
    }
}