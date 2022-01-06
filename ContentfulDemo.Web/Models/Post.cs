using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models
{
    public class Post
    {
        public SystemProperties Sys { get; set; }
        public string Title { get; set; }
        public string Headline { get; set; }
        public Document Content { get; set; }
        public string Slug { get; set; }
        public Asset Hero { get; set; }
        public Author Author { get; set; }
        public List<Category> Categories { get; set; }
        public int Like { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
