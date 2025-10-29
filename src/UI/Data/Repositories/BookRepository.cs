using Microsoft.EntityFrameworkCore;
using UI.Contracts.Repositories;
using UI.Models.DTOs;

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
    }
}
