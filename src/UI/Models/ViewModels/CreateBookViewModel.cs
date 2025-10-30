using UI.Models.Entities;

namespace UI.Models.ViewModels
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public int PagesCount { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
