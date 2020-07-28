using MongoDB.Driver;
using SmartForm.Common.Repository;
using SmartForm.Services.Category.Domain.Models;

namespace SmartForm.Services.Category.Repository
{
    public class CategoryRepository : MongoRepository<FolderModel>, ICategoryRepository
    {
        public CategoryRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}