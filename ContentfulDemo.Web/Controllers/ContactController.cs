using ContentfulDemo.Web.Filters;
using ContentfulDemo.Web.Models.FormModels;
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
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IBlogUsecase _blogUsecase;

        public ContactController(ILogger<ContactController> logger, IBlogUsecase blogUsecase)
        {
            _logger = logger;
            _blogUsecase = blogUsecase;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _blogUsecase.GetContactPageData();
            return View(model);
        }

        [HttpPost]
        [SlowModeFilter(5)]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            var formModel = model.ContactMessage;
            await _blogUsecase.CreateContactMessage(formModel);
            return RedirectToAction("Index");
        }
    }
}
