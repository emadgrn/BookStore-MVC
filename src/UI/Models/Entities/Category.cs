using System.ComponentModel.DataAnnotations;

namespace UI.Models.Entities
{
    public class Category
    {
        [Display(Name = "شناسه دسته‌بندی")]
        public int Id { get; set; }

        [Display(Name = "عنوان دسته‌بندی")]
        public string Name { get; set; }

        [Display(Name = "توصیف مختصر")]
        public string BriefDescription { get; set; }

        [Display(Name = "آدرس تصویر")]
        public string ImageUrl { get; set; }

        public List<Book> Books { get; set; }
    }
}
