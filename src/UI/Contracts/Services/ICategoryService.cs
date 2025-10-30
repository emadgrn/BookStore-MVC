using UI.Models.DTOs;

namespace UI.Contracts.Services
{
    public interface ICategoryService
    {
        List<GetCategoryDto> GetAll();
        public List<String> GetAllCategoriesNames();
    }
}
