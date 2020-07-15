using SmartForm.Common.Services;
using SmartForm.Services.Form.Domain.Models;

namespace SmartForm.Services.Form.Services
{
    public class FormService : EntityService<FormModel>, IFormService
    {
        public FormService(IFormRepository formRepository) : base(formRepository)
        {
        }
    }
}