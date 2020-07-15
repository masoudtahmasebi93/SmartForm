using MongoDB.Driver;
using SmartForm.Common.Repository;
using SmartForm.Services.Activities.Domain.Models;

namespace SmartForm.Services.Activities.Repositories
{
    public class FolderRepository : MongoRepository<FolderModel>, IFolderRepository
    {
        public FolderRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}