using UI.Models.DTOs;

namespace UI.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetAll();
        List<String> GetAllCategoriesNames();

        
    }
}
