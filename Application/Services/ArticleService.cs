using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArticleService
    {
        private readonly ArticleRepository _articleRepository;

        public ArticleService(ApplicationContext dbContext)
        {
            _articleRepository = new (dbContext);
        }

        public async Task Update(SaveArticleViewModel vm)
        {
            Article article = new();
            article.Id = vm.Id;
            article.Name = vm.Name;
            article.Price = vm.Price;
            article.Description = vm.Description;
            article.ImageUrl = vm.ImageUrl;
            article.CategoryId = vm.CategoryId;

            await _articleRepository.UpdateAsync(article);
        }

        public async Task Add(SaveArticleViewModel vm)
        {
            Article article = new();
            article.Name = vm.Name;
            article.Price = vm.Price;
            article.Description = vm.Description;
            article.ImageUrl = vm.ImageUrl;
            article.CategoryId = vm.CategoryId;

            await _articleRepository.AddAsync(article);
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
            var articleList = await _articleRepository.GetAllAsync();

            return articleList.Select(article => new ArticleViewModel
            {
                Name = article.Name,
                Description = article.Description,
                Id = article.Id,
                Price = article.Price,
                ImageUrl = article.ImageUrl
            }).ToList();
        }

    }
}
