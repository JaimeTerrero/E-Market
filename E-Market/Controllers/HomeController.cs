using Application.Services;
using Database;
using E_Market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleService _articleService;

        public HomeController(ApplicationContext dbContext)
        {
            _articleService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {

            return View(await _articleService.GetAllViewModel());
        }
    }
}
