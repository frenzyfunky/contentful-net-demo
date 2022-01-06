using ContentfulDemo.Web.Usecases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IBlogUsecase _blogUsecase;

        public SidebarViewComponent(IBlogUsecase blogUsecase)
        {
            _blogUsecase = blogUsecase;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _blogUsecase.GetSidebarData();
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
}
