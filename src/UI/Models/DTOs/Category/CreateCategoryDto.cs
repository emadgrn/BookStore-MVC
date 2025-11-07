using System.ComponentModel.DataAnnotations;

namespace UI.Models.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        public string? BriefDescription { get; set; }

        public string? ImageUrl { get; set; }
    }
}
