namespace UI.Models.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public int PagesCount { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
