using System.Threading.Tasks;
using MongoDB.Driver;
using SmartForm.Common.Repository;
using SmartForm.Services.Form.Domain.Models;

namespace SmartForm.Services.Form.Services
{
    public class FormRepository : MongoRepository<FormModel>, IFormRepository
    {
        
        public FormRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}