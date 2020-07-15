using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SmartForm.Common.Mongo;
using SmartForm.Services.Activities.Domain.Models;
using SmartForm.Services.Activities.Repositories;

namespace SmartForm.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IReportRepository _reportRepository;

        public CustomMongoSeeder(IMongoDatabase database,
            IFolderRepository folderRepository,
           IReportRepository reportRepository)
            : base(database)
        {
            _folderRepository = folderRepository;
            _reportRepository = reportRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var folders = new List<string>
            {
                "work",
                "sport",
                "hobby"
            };
            await Task.WhenAll(folders.Select(x => _folderRepository
                .AddAsync(new FolderModel(x))));
            
        }
    }
}