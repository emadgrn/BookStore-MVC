using UI.Models.DTOs.Book;
using UI.Models.ViewModels;

namespace UI.Contracts.Services
{
    public interface IBookService
    {
        List<GetBookDto> GetLimitedLatestBooks();
        void CreateNewBook(CreateBookViewModel model);

    }
}
