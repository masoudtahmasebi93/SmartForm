using SmartForm.Common.Events;

namespace SmartForm.Services.Identity
{
    public class UserAuthenticated : IEvent
    {
        protected UserAuthenticated()
        {
        }

        public UserAuthenticated(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}