using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartForm.Common.Services
{
    public interface IEntityService<T> : IBaseService
    {
        Task AddAsync(T model);
        Task UpdateAsync(Guid id, T model);
        Task RemoveAsync(Guid id);
        Task<List<T>> GetAsync();
        Task<T> GetAsync(Guid id);
        bool Any(Guid id);
        Task<T> GetAsync(string name);
        Task UpdateAsync(Guid id, string field, T model);
    }
}