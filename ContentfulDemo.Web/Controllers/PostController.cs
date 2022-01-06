using ContentfulDemo.Web.Models.ViewModels;
using ContentfulDemo.Web.Usecases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IBlogUsecase _blogUsecase;

        public PostController(ILogger<PostController> logger, IBlogUsecase blogUsecase)
        {
            _logger = logger;
            _blogUsecase = blogUsecase;
        }

        public async Task<IActionResult> Detail(string slug)
        {
            var post = await _blogUsecase.GetPostDetail(slug);
            var viewModel = new PostDetailViewModel
            {
                Post = post
            };

            return View(viewModel);
        }
    }
}
