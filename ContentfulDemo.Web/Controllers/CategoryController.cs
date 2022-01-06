using ContentfulDemo.Web.Usecases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IBlogUsecase _blogUsecase;

        public CategoryController(ILogger<CategoryController> logger, IBlogUsecase blogUsecase)
        {
            _logger = logger;
            _blogUsecase = blogUsecase;
        }

        public async Task<IActionResult> Index(string category, [FromQuery] string categoryId, [FromQuery] int? pageNumber)
        {
            var model = await _blogUsecase.GetPostsByCategory(category, categoryId, pageNumber);
            return View(model);
        }
    }
}
