using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SmartForm.Common.Domain.Models;
using SmartForm.Common.Exceptions;

namespace SmartForm.Common.Repository
{
    public class MongoRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<T> Collection
            => _database.GetCollection<T>(typeof(T).Name);

        public virtual async Task AddAsync(T model)
        {
            try
            {
                await Collection.InsertOneAsync(model);
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public virtual async Task UpdateSingleFieldAsync(Guid id, dynamic fieldValue)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("Id", id);

                //var t = model.GetType();
                //var prop = t.GetProperty(field);

                var update = Builders<T>.Update.Set(fieldValue.GetType().Name, fieldValue.GetType().Name);
                await Collection.UpdateOneAsync(filter, update);
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public virtual async Task UpdateAsync(Guid id, T model)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("Id", id);
                await Collection.ReplaceOneAsync(filter, model);
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("Id", id);
                await Collection.DeleteOneAsync(filter);
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public virtual async Task<List<T>> GetAsync()
        {
            try
            {
                return await Collection.AsQueryable().ToListAsync();
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        public virtual List<T> Get(Func<T, bool> predicate = null)
        {
            try
            {
                return Collection.AsQueryable().Where(predicate).ToList<T>();
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            try
            {
                return await Collection.AsQueryable().FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public virtual async Task<T> GetAsync(string name)
        {
            try
            {
                return await Collection.AsQueryable().FirstOrDefaultAsync(a => a.Name == name);
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public bool Any(Guid id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("Id", id);
                return Collection.FindSync(filter).Any(CancellationToken.None);
            }
            catch (SmartFormException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}