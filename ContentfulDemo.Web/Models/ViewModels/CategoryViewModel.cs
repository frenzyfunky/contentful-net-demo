using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<Post> Posts { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext { get { return CurrentPage < TotalPage; } }
        public bool HasPrevious { get { return CurrentPage > 1; } }
    }
}
