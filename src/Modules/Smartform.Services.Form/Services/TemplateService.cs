using SmartForm.Common.Services;
using SmartForm.Services.Form.Domain.Models;
using SmartForm.Services.Form.Repository;

namespace SmartForm.Services.Form.Services
{
    public class TemplateService : EntityService<TemplateModel>, ITemplateService
    {
        public TemplateService(ITemplateRepository templateRepository) : base(templateRepository)
        {
        }
    }
}