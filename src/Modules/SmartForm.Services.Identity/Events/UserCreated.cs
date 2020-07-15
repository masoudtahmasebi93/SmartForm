using SmartForm.Common.Events;

namespace SmartForm.Services.Identity
{
    public class UserCreated : IEvent
    {
        protected UserCreated()
        {
        }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }

        public string Email { get; }
        public string Name { get; }
    }
}