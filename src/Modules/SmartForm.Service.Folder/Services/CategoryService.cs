using SmartForm.Common.Services;
using SmartForm.Services.Category.Domain.Models;
using SmartForm.Services.Category.Repository;

namespace SmartForm.Services.Category.Services
{
    public class CategoryService : EntityService<FolderModel>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
    }
}