using UI.Models.DTOs;

namespace UI.Contracts.Repositories
{
    public interface IBookRepository
    {
        List<GetBookDto> GetLatestBooks(int topItems);
        void Create(CreateBookDto model);
    }
}
