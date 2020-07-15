using System.Threading.Tasks;
using SmartForm.Common.Auth;
using SmartForm.Common.Exceptions;
using SmartForm.Services.Identity.Domain.Models;
using SmartForm.Services.Identity.Domain.Repositories;
using SmartForm.Services.Identity.Domain.Services;

namespace SmartForm.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository,
            IEncrypter encrypter,
            IJwtHandler jwtHandler)
        {
            _repository = repository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _repository.GetAsync(email);
            if (user != null)
                throw new SmartFormException("email_in_use",
                    $"Email: '{email}' is already in use.");
            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _repository.AddAsync(user);
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _repository.GetAsync(email);
            if (user == null)
                throw new SmartFormException("invalid_credentials",
                    "Invalid credentials.");
            if (!user.ValidatePassword(password, _encrypter))
                throw new SmartFormException("invalid_credentials",
                    "Invalid credentials.");

            return _jwtHandler.Create(user.Id);
        }
    }
}