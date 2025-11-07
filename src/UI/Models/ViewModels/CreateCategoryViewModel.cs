namespace UI.Models.ViewModels
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }

        public string? BriefDescription { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
