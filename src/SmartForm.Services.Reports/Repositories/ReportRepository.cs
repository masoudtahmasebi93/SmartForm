using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SmartForm.Common.Repository;
using SmartForm.Services.Activities.Domain.Models;

namespace SmartForm.Services.Activities.Repositories
{
    public class ReportRepository : MongoRepository<ReportModel>, IReportRepository
    {
        private readonly IMongoDatabase _database;

        public ReportRepository(IMongoDatabase database) : base(database)
        {
            _database = database;
        }

        // public ReportRepository(IMongoDatabase database)
        // {
        //     _database = database;
        // }

        private IMongoCollection<ReportModel> Collection
            => _database.GetCollection<ReportModel>("Reports");

        public async Task AddAsync(ReportModel reportModel)
        {
            await Collection.InsertOneAsync(reportModel);
        }


        public async Task<ReportModel> GetAsync(Guid id)
        {
            return await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await Collection.DeleteOneAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<ReportModel>> BrowseAsync(Guid userId)
        {
            return await Collection
                .AsQueryable()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}