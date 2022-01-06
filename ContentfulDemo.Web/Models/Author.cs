using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models
{
    public class Author
    {
        public string AuthorName { get; set; }
        public Asset Image { get; set; }
        public string Bio { get; set; }
    }
}
