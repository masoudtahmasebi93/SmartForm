using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartForm.Common.Repository;
using SmartForm.Services.Activities.Domain.Models;

namespace SmartForm.Services.Activities.Repositories
{
    public interface IReportRepository: IBaseRepository<ReportModel>
    {
        // Task<ReportModel> GetAsync(Guid id);
        // Task<IEnumerable<ReportModel>> BrowseAsync(Guid userId);
        // Task AddAsync(ReportModel reportModel);
    }
}