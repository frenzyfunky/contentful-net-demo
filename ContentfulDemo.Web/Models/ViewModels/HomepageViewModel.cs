using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models.ViewModels
{
    public class HomepageViewModel
    {
        public HomepageHero HomepageHero { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
