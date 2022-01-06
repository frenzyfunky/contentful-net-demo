using ContentfulDemo.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models.ViewModels
{
    public class ContactViewModel : Contact
    {
        public ContactMessage ContactMessage { get; set; }
    }
}
