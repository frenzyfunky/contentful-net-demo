using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models.ViewModels
{
    public class SidebarViewModel
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Post> PopularArticles { get; set; } = new List<Post>();
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public class Category
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public string Slug { get; set; }
            public string Id { get; set; }
        }
    }
}
