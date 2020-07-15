using SmartForm.Common.Commands;

namespace SmartForm.Services.Identity
{
    public class AuthenticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}