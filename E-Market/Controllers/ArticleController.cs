using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Market.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleService _articleService;

        public ArticleController(ApplicationContext dbContext)
        {
            _articleService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _articleService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveArticle", new SaveArticleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveArticleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveArticle", vm);
            }

            await _articleService.Add(vm);
            return RedirectToRoute(new { controller = "Article", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveArticle", await _articleService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveArticleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveArticle", vm);
            }

            await _articleService.Update(vm);
            return RedirectToRoute(new { controller = "Article", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _articleService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _articleService.Delete(id);
            return RedirectToRoute(new { controller = "Article", action = "Index" });
        }
    }
}
