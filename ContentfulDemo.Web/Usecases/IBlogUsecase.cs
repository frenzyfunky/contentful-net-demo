using ContentfulDemo.Web.Models;
using ContentfulDemo.Web.Models.FormModels;
using ContentfulDemo.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Usecases
{
    public interface IBlogUsecase
    {
        Task<HomepageViewModel> GetHomepageData();
        Task<Post> GetPostDetail(string slug);
        Task<SidebarViewModel> GetSidebarData();
        Task<CategoryViewModel> GetPostsByCategory(string category, string categoryId = null, int? pageNumber = null);
        Task<BlogViewModel> GetPosts(int? pageNumber);
        Task<HomepageViewModel> GetAboutPageData();
        Task<ContactViewModel> GetContactPageData();
        Task CreateContactMessage(ContactMessage message);
    }
}
