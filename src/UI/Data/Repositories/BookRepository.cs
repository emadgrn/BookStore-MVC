using Microsoft.EntityFrameworkCore;
using UI.Contracts.Repositories;
using UI.Models.DTOs.Book;
using UI.Models.Entities;

namespace UI.Data.Repositories
{
    public class BookRepository:IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GetBookDto> GetLatestBooks(int topItems)
        {
            return _context.Books
                .OrderByDescending(b => b.CreatedAt)
                .Take(topItems)                     
                .Select(b => new GetBookDto            
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorName = b.AuthorName,
                    PagesCount = b.PagesCount,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    CreatedAt = b.CreatedAt
                })
                .ToList();
        }

        public void Create(CreateBookDto model)
        {
            var entity = new Book()
            {
                Title = model.Title,
                AuthorName = model.AuthorName,
                PagesCount = model.PagesCount,
                Price = model.Price,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                CreatedAt = DateTime.Now
            };
            _context.Books.Add(entity);
            _context.SaveChanges();
        }
    }
}
