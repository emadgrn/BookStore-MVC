using UI.Models.DTOs.Book;
using UI.Models.DTOs.Category;

namespace UI.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<GetBookDto> LatestBooks { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
    }
}
