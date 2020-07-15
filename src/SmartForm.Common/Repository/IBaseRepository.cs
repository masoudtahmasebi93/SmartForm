using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartForm.Common.Repository
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T model);
        Task UpdateAsync(Guid id, string field, T model);
        Task UpdateModelAsync(Guid id, string field, T model);
        Task RemoveAsync(Guid id);
        Task<List<T>> GetAsync();
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(string name);
        bool Any(Guid id);
    }
}