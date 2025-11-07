namespace UI.Models.ViewModels
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? BriefDescription { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
