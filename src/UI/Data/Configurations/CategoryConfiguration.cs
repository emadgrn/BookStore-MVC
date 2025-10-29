using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Models.Entities;

namespace UI.Data.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasData(
                new Category { Id = 1, Name = "رمان و داستان", BriefDescription = "معاصر، کلاسیک", ImageUrl = "/images/categories/books-icon.png" },
                new Category { Id = 2, Name = "فلسفه و منطق", BriefDescription = "غرب و شرق", ImageUrl = "/images/categories/brain-icon.png" },
                new Category { Id = 3, Name = "علمی و تاریخی", BriefDescription = "فناوری و تاریخ", ImageUrl = "/images/categories/microscope-icon.png" },
                new Category { Id = 4, Name = "کودک و نوجوان", BriefDescription = "داستان‌های مصور", ImageUrl = "/images/categories/child-icon.png" },
                new Category { Id = 5, Name = "هنر و معماری", BriefDescription = "طراحی و نقاشی", ImageUrl = "/images/categories/art-icon.png" }
            );
        }
    }
}
