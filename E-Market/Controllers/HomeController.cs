using Application.Services;
using E_Market.Middlewares;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Articles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(IArticleService articleService, ICategoryService categoryService, ValidateUserSession validateUserSession)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index(FilterArticleViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            ViewBag.Categories = await _categoryService.GetAllViewModel();
            return View(await _articleService.GetAllViewModelWithFilters(vm));
        }
    }
}
