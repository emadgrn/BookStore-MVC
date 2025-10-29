using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Models.Entities;

namespace UI.Data.Configurations
{
    public class BookConfiguration:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);

            builder.Property(b => b.CategoryId).IsRequired();

            builder.Property(b => b.Price).HasColumnType("decimal(10,2)");

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "غریبه",
                    AuthorName = "آلبر کامو",
                    Price = 450000,
                    PagesCount = 120,
                    ImageUrl = "/images/books/the-stranger.jpg",
                    CreatedAt = new DateTime(2025, 06, 15, 0, 0, 0),
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "جنگ و صلح",
                    AuthorName = "لئو تولستوی",
                    Price = 600000,
                    PagesCount = 1225,
                    ImageUrl = "/images/books/war-and-peace.jpg",
                    CreatedAt = new DateTime(2025, 06, 16, 0, 0, 0),
                    CategoryId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "پیامبر",
                    AuthorName = "جبران خلیل جبران",
                    Price = 380000,
                    PagesCount = 100,
                    ImageUrl = "/images/books/the-prophet.jpg",
                    CreatedAt = new DateTime(2025, 06, 17, 0, 0, 0),
                    CategoryId = 2
                },
                new Book
                {
                    Id = 4,
                    Title = "شازده کوچولو",
                    AuthorName = "آنتوان دو سنت‌اگزوپری",
                    Price = 250000,
                    PagesCount = 90,
                    ImageUrl = "/images/books/The-Little-Prince.jpg",
                    CreatedAt = new DateTime(2025, 06, 18, 0, 0, 0),
                    CategoryId = 4
                },
                new Book
                {
                    Id = 5,
                    Title = "نظریه‌ی همه‌چیز",
                    AuthorName = "استیون هاوکینگ",
                    Price = 500000,
                    PagesCount = 160,
                    ImageUrl = "/images/books/THE-THEORY-OF-EVERYTHING.jpg",
                    CreatedAt = new DateTime(2025, 06, 19, 0, 0, 0),
                    CategoryId = 3
                }

            );
        }
    }
}
