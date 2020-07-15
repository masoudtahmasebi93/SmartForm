using System;
using System.Threading.Tasks;

namespace SmartForm.Services.Activities.Services
{
    public interface IReportService
    {
        Task AddAsync(Guid id, Guid userId, string category,
            string name, string description, DateTime createdAt);
    }
}