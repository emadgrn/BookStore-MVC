using UI.Contracts.Repositories;
using UI.Models.DTOs;

namespace UI.Data.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GetCategoryDto> GetAll()
        {
            return _context.Categories
                .Select(c => new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    BriefDescription = c.BriefDescription,
                    ImageUrl = c.ImageUrl
                }).ToList();
        }
    }
}
