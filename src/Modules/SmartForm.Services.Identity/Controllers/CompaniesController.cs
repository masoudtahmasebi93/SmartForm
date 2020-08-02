using SmartForm.Common.Controllers;
using SmartForm.Services.Identity.Domain.Models;
using SmartForm.Services.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartForm.Services.Identity.Controllers
{
    public class CompaniesController : GenericController<CompanyModel>
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService) : base(companyService)
        {

        }
    }
}
