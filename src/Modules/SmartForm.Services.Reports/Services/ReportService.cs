using System;
using System.Threading.Tasks;
using SmartForm.Common.Exceptions;
using SmartForm.Services.Activities.Domain.Models;
using SmartForm.Services.Activities.Repositories;

namespace SmartForm.Services.Activities.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IFolderRepository _folderRepository;

        public ReportService(IReportRepository reportRepository,
            IFolderRepository folderRepository)
        {
            _reportRepository = reportRepository;
            _folderRepository = folderRepository;
        }

        public async Task AddAsync(Guid id, Guid? userId, string category,
            string name, string description, DateTime createdAt)
        {
            FolderModel reportFolderModel = await _folderRepository.GetAsync(category);
            if (reportFolderModel == null)
                throw new SmartFormException("category_not_found",
                    $"Category: '{category}' was not found.");
            var activity = new ReportModel(id, reportFolderModel, userId,
                name, description, createdAt);
            await _reportRepository.AddAsync(activity);
        }
    }
}