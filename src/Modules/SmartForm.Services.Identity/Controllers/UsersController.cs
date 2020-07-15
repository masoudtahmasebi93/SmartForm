using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace SmartForm.Services.Identity
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IBusClient _busClient;

        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }

     

        [HttpGet("loginauth")]
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
    }
}