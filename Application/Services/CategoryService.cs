using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Categories;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpcontextAccessor;
        private readonly UserViewModel userViewModel;

        public CategoryService(ICategoryRepository categoryRepository, IHttpContextAccessor httpcontextAccessor)
        {
            _categoryRepository = categoryRepository;
            _httpcontextAccessor = httpcontextAccessor;
            userViewModel = _httpcontextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task Update(SaveCategoryViewModel vm)
        {
            Category category = await _categoryRepository.GetByIdAsync(vm.Id);
            category.Id = vm.Id;
            category.Name = vm.Name;

            await _categoryRepository.UpdateAsync(category);
        }

        public async Task<SaveCategoryViewModel> Add(SaveCategoryViewModel vm)
        {
            Category category = new();
            category.Name = vm.Name;

            category = await _categoryRepository.AddAsync(category);

            SaveCategoryViewModel categoryVm = new();
            categoryVm.Id = category.Id;
            categoryVm.Name = category.Name;

            return categoryVm;
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<SaveCategoryViewModel> GetByIdSaveViewModel(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            SaveCategoryViewModel vm = new();
            vm.Id = category.Id;
            vm.Name = category.Name;

            return vm;
        }

        public async Task<List<CategoryViewModel>> GetAllViewModel()
        {
            var categoryList = await _categoryRepository.GetAllWithIncludeAsync(new List<string> { "Articles"});

            return categoryList.Select(category => new CategoryViewModel
            {
                Name = category.Name,
                Id = category.Id,
                ArticlesQuantity = category.Articles.Where(article => article.UserId == userViewModel.Id).Count()
            }).ToList();
        }

    }
}
