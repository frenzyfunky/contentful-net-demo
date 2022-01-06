using ContentfulDemo.Web.Usecases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogUsecase _blogUsecase;

        public BlogController(ILogger<BlogController> logger, IBlogUsecase blogUsecase)
        {
            _logger = logger;
            _blogUsecase = blogUsecase;
        }
        public async Task<IActionResult> Index([FromQuery] int? pageNumber)
        {
            var model = await _blogUsecase.GetPosts(pageNumber.GetValueOrDefault(1));
            return View(model);
        }
    }
}
