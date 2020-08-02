using MongoDB.Driver;
using SmartForm.Common.Repository;
using SmartForm.Services.Identity.Domain.Models;
using SmartForm.Services.Identity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartForm.Services.Identity.Repositories
{
    public class CompanyRepository : MongoRepository<CompanyModel>, ICompanyRepository
    {
        public CompanyRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}
