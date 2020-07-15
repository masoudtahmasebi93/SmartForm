using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartForm.Common.Repository;

namespace SmartForm.Common.Services
{
    public class EntityService<T> : IEntityService<T>
    {
        public readonly IBaseRepository<T> _baseRepository;

        public EntityService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }


        public virtual async Task AddAsync(T model)
        {
            await _baseRepository.AddAsync(model);
        }

        public bool Any(Guid id)
        {
            return _baseRepository.Any(id);
        }
        
        public virtual async Task<List<T>> GetAsync()
        {
            return await _baseRepository.GetAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _baseRepository.GetAsync(id);
        }

        public virtual async Task<T> GetAsync(string name)
        {
            return await _baseRepository.GetAsync(name);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            await _baseRepository.RemoveAsync(id);
        }

        public virtual async Task UpdateAsync(Guid id, string field, T model)
        {
            await _baseRepository.UpdateModelAsync(id, field, model);
        }

        public Task UpdateAsync(Guid id, T model)
        {
            throw new NotImplementedException();
        }
    }
}