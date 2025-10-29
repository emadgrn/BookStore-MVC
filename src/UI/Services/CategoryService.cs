using UI.Contracts.Repositories;
using UI.Contracts.Services;
using UI.Models.DTOs;

namespace UI.Services
{
    public class CategoryService(ICategoryRepository categoryRepo): ICategoryService
    {
        public List<GetCategoryDto> GetAll()
        {
            return categoryRepo.GetAll();
        }

    }
}
