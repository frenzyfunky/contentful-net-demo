using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models
{
    public class Category
    {
        public SystemProperties Sys { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public Asset Image { get; set; }
    }
}
