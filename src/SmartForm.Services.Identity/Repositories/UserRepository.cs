using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SmartForm.Services.Identity.Domain.Models;
using SmartForm.Services.Identity.Domain.Repositories;

namespace SmartForm.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<User> Collection
            => _database.GetCollection<User>("Users");

        public async Task<User> GetAsync(Guid id)
        {
            return await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetAsync(string email)
        {
            return await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());
        }

        public async Task AddAsync(User user)
        {
            await Collection.InsertOneAsync(user);
        }
    }
}