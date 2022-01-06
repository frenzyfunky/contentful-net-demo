using ContentfulDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.ViewComponents
{
    public class PostPreviewViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<Post> posts)
        {
            return await Task.FromResult((IViewComponentResult)View(posts));
        }
    }
}
