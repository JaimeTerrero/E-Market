using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Articles;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IHttpContextAccessor _httpcontextAccessor;
        private readonly UserViewModel userViewModel;
        public ArticleService(IArticleRepository articleRepository, IHttpContextAccessor httpcontextAccessor)
        {
            _articleRepository = articleRepository;
            _httpcontextAccessor = httpcontextAccessor;
            userViewModel = _httpcontextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task Update(SaveArticleViewModel vm)
        {
            Article article = await _articleRepository.GetByIdAsync(vm.Id);
            article.Id = vm.Id;
            article.Name = vm.Name;
            article.Price = vm.Price;
            article.Description = vm.Description;
            article.ImageUrl = vm.ImageUrl;
            article.CategoryId = vm.CategoryId;

            await _articleRepository.UpdateAsync(article);
        }

        public async Task<SaveArticleViewModel> Add(SaveArticleViewModel vm)
        {
            Article article = new();
            article.Name = vm.Name;
            article.Price = vm.Price;
            article.Description = vm.Description;
            article.CategoryId = vm.CategoryId;
            article.UserId = userViewModel.Id;

            article = await _articleRepository.AddAsync(article);

            SaveArticleViewModel articleVm = new();
            articleVm.Id = article.Id;
            articleVm.Name = article.Name;
            articleVm.Price = article.Price;
            articleVm.Description = article.Description;
            articleVm.ImageUrl = article.ImageUrl;
            articleVm.CategoryId = article.CategoryId;

            return articleVm;
        }

        public async Task Delete(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            await _articleRepository.DeleteAsync(article);
        }

        public async Task<SaveArticleViewModel> GetByIdSaveViewModel(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            SaveArticleViewModel vm = new();
            vm.Id = article.Id;
            vm.Name = article.Name;
            vm.Description = article.Description;
            vm.Price = article.Price;
            vm.ImageUrl = article.ImageUrl;
            vm.CategoryId = article.CategoryId;

            return vm;
        }

        public async Task<List<ArticleViewModel>> GetAllViewModel()
        {
            var articleList = await _articleRepository.GetAllWithIncludeAsync(new List<string> {"Category" });

            return articleList.Where(article => article.UserId == userViewModel.Id).Select(article => new ArticleViewModel
            {
                Name = article.Name,
                Description = article.Description,
                Id = article.Id,
                Price = article.Price,
                ImageUrl = article.ImageUrl,
                CategoryName = article.Category.Name,
                CategoryId = article.Category.Id
            }).ToList();
        }

        public async Task<List<ArticleViewModel>> GetAllViewModelWithFilters(FilterArticleViewModel filters)
        {
            var articleList = await _articleRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            var listViewModels = articleList.Where(article => article.UserId == userViewModel.Id).Select(article => new ArticleViewModel
            {
                Name = article.Name,
                Description = article.Description,
                Id = article.Id,
                Price = article.Price,
                ImageUrl = article.ImageUrl,
                CategoryName = article.Category.Name,
                CategoryId = article.Category.Id
            }).ToList();

            if(filters.CategoryId != null)
            {
                listViewModels = listViewModels.Where(product => product.CategoryId == filters.CategoryId.Value).ToList();
            }

            return listViewModels;
        }
    }
}
