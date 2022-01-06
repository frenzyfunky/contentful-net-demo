using ContentfulDemo.Web.Usecases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly IBlogUsecase _blogUsecase;

        public AboutController(ILogger<AboutController> logger, IBlogUsecase blogUsecase)
        {
            _logger = logger;
            _blogUsecase = blogUsecase;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _blogUsecase.GetAboutPageData();
            return View(model);
        }
    }
}
