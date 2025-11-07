using System.Net;
using UI.Contracts.Repositories;
using UI.Contracts.Services;
using UI.Models.DTOs.Book;
using UI.Models.DTOs.Category;
using UI.Models.DTOs.User;
using UI.Models.Entities._common;
using UI.Models.ViewModels;

namespace UI.Services
{
    public class CategoryService(ICategoryRepository categoryRepo) : ICategoryService
    {
        public void CreateCategory(CreateCategoryViewModel model)
        {
            var imgAddress = "";

            if (model.ImageFile is not null)
            {
                imgAddress = FileService.Upload(model.ImageFile!);
            }

            var modelDto = new CreateCategoryDto()
            {
                Name = model.Name,
                BriefDescription = model.BriefDescription,
                ImageUrl = imgAddress
            };
            categoryRepo.Create(modelDto);
        }

        public List<GetCategoryDto> GetAll()
        {
            return categoryRepo.GetAll();
        }


        public List<String> GetAllCategoriesNames()
        {
            return categoryRepo.GetAllCategoriesNames();
        }

        public Result<GetCategoryDto> GetCategoryById(int id)
        {
            var categoryDto = categoryRepo.GetById(id);

            if (categoryDto is not null)
            {
                return Result<GetCategoryDto>.Success("", categoryDto);
            }
            else
            {
                return Result<GetCategoryDto>.Failure($"دسته بندی با این آیدی {id} وجود ندارد");
            }
        }

        public Result<bool> Update(int categoryId, GetCategoryDto model)
        {
            var result = categoryRepo.Update(categoryId, model);

            if (result)
            {
                return Result<bool>.Success("اطلاعات دسته بندی با موفقیت به‌روزرسانی شد.");
            }
            else
            {
                return Result<bool>.Failure("به‌روزرسانی اطلاعات دسته بندی با خطا مواجه شد.");
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            return categoryRepo.DeleteById(categoryId);
        }

    }
}
