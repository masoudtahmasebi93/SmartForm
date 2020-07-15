using SmartForm.Common.Events;

namespace SmartForm.Services.Identity
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        protected AuthenticateUserRejected()
        {
        }

        public AuthenticateUserRejected(string email,
            string code, string reason)
        {
            Email = email;
            Code = code;
            Reason = reason;
        }

        public string Email { get; }
        public string Code { get; }
        public string Reason { get; }
    }
}