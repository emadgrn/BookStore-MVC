using UI.Models.DTOs;
using UI.Models.ViewModels;

namespace UI.Contracts.Services
{
    public interface IBookService
    {
        List<GetBookDto> GetLimitedLatestBooks();
        void CreateNewBook(CreateBookDto model);
    }
}
