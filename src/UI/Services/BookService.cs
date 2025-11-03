using UI.Contracts.Repositories;
using UI.Contracts.Services;
using UI.Data.Repositories;
using UI.Models.DTOs;
using UI.Models.Entities;
using UI.Models.ViewModels;

namespace UI.Services
{
    public class BookService(IBookRepository bookRepo): IBookService
    {

        public List<GetBookDto> GetLimitedLatestBooks()
        {
            const int topItems = 6;
            return bookRepo.GetLatestBooks(topItems);
        }

        public void CreateNewBook(CreateBookViewModel model)
        {
            var imgAddress = FileService.Upload(model.ImageFile);

            var modelDto = new CreateBookDto()
            {
                Title = model.Title,
                AuthorName = model.AuthorName,
                PagesCount = model.PagesCount,
                Price = model.Price,
                CategoryId = model.CategoryId,
                ImageUrl = imgAddress
            };
            bookRepo.Create(modelDto);
        }

    }
}
