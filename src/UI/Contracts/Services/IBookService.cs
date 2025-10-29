using UI.Models.DTOs;

namespace UI.Contracts.Services
{
    public interface IBookService
    {
        List<GetBookDto> GetLimitedLatestBooks();
    }
}
