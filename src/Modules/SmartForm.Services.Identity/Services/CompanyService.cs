using SmartForm.Common.Services;
using SmartForm.Services.Identity.Domain.Models;
using SmartForm.Services.Identity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartForm.Services.Identity.Services
{
    public class CompanyService : EntityService<CompanyModel>, ICompanyService

    {
        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
        }
    }
}
