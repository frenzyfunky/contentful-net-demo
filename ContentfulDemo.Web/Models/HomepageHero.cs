using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models
{
    public class HomepageHero
    {
        public Asset Avatar { get; set; }
        public string Name { get; set; }
        public string Headline { get; set; }
        public Asset BackgroundImage { get; set; }
    }
}
