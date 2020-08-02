using SmartForm.Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartForm.Services.Identity.Domain.Models
{
    public class CompanyModel : BaseModel
    {
        public List<User>? Users { get; set; }
    }
}
