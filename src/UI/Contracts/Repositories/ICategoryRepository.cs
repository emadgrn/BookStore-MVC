using UI.Models.DTOs.Category;

namespace UI.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetAll();
        List<String> GetAllCategoriesNames();
        public void Create(CreateCategoryDto model);
        public GetCategoryDto? GetById(int id);
        public bool Update(int categoryId, GetCategoryDto model);
        public bool DeleteById(int categoryId);



    }
}
