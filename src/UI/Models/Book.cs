using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "عنوان کتاب")]
        public string Title { get; set; }
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "آدرس تصویر")]
        public string ImageUrl { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
