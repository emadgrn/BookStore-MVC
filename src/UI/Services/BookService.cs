using UI.Contracts.Repositories;
using UI.Contracts.Services;
using UI.Models.DTOs;
using UI.Models.ViewModels;

namespace UI.Services
{
    public class BookService(IBookRepository bookRepo): IBookService
    {
        public List<GetBookDto> GetLimitedLatestBooks()
        {
            const int topItems = 5;
            return bookRepo.GetLatestBooks(topItems);
        }

        public void CreateNewBook(CreateBookDto model)
        {
            bookRepo.Create(model);
        }
    }
}
