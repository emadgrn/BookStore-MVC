using UI.Models.DTOs.Category;

namespace UI.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetAll();
        List<String> GetAllCategoriesNames();

        
    }
}
