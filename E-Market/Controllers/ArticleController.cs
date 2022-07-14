using Application.Services;
using E_Market.Middlewares;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Articles;
using EMarket.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace E_Market.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ValidateUserSession _validateUserSession;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, ValidateUserSession validateUserSession)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _articleService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveArticleViewModel vm = new();
            vm.Categories = await _categoryService.GetAllViewModel();
            return View("SaveArticle", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveArticleViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                vm.Categories = await _categoryService.GetAllViewModel();
                return View("SaveArticle", vm);
            }

            SaveArticleViewModel articleVm = await _articleService.Add(vm);
            if (articleVm != null && articleVm.Id != 0)
            {
                articleVm.ImageUrl = UploadFile(vm.File, articleVm.Id);
                await _articleService.Update(articleVm);
            }
            return RedirectToRoute(new { controller = "Article", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveArticleViewModel vm = await _articleService.GetByIdSaveViewModel(id);
            vm.Categories = await _categoryService.GetAllViewModel();
            return View("SaveArticle", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveArticleViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                vm.Categories = await _categoryService.GetAllViewModel();
                return View("SaveArticle", vm);
            }

            SaveArticleViewModel articleVm = await _articleService.GetByIdSaveViewModel(vm.Id);
            vm.ImageUrl = UploadFile(vm.File, articleVm.Id, true, articleVm.ImageUrl);

            await _articleService.Update(vm);
            return RedirectToRoute(new { controller = "Article", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _articleService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            await _articleService.Delete(id);
            //get directory path
            string basePath = $"/Images/Articles/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }

            return RedirectToRoute(new { controller = "Article", action = "Index" });
        }

        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imageUrl = "")
        {
            if (isEditMode && file == null)
            {
                return imageUrl;
            }
            //get directory path
            string basePath = $"/Images/Articles/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            // create folder if not existe
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file path
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string filename = guid + fileInfo.Extension;

            string filenameWithPath = Path.Combine(path, filename);

            using(var stream = new FileStream(filenameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imageUrl.Split("/");
                string oldImageName = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }

            return $"{basePath}/{filename}";
        }
    }
}
