using SmartForm.Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartForm.Common.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task AddAsync(T model);
        Task UpdateSingleFieldAsync(Guid id, dynamic fieldValue);
        Task UpdateAsync(Guid id, T model);
        Task RemoveAsync(Guid id);
        Task<List<T>> GetAsync();
        List<T> Get(Func<T, bool> predicate = null);
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(string name);
        bool Any(Guid id);
    }
}