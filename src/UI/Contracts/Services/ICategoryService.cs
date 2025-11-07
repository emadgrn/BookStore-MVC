using UI.Models.DTOs.Category;
using UI.Models.Entities._common;
using UI.Models.ViewModels;

namespace UI.Contracts.Services
{
    public interface ICategoryService
    {
        List<GetCategoryDto> GetAll();
        public List<String> GetAllCategoriesNames();
        public void CreateCategory(CreateCategoryViewModel model);
        public Result<GetCategoryDto> GetCategoryById(int id);
        public Result<bool> Update(int categoryId, GetCategoryDto model);
        public bool DeleteCategory(int categoryId);

    }

}
