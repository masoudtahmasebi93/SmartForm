using MongoDB.Driver;
using SmartForm.Common.Repository;
using SmartForm.Services.Form.Domain.Models;

namespace SmartForm.Services.Form.Repository
{
    public class TemplateRepository : MongoRepository<TemplateModel>, ITemplateRepository
    {
        public TemplateRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}