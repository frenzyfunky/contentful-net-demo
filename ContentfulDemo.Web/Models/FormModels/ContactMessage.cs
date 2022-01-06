using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Models.FormModels
{
    public class ContactMessage
    {
        private const string ERROR_MESSAGE = "This field cannot be empty";

        [Required(ErrorMessage = ERROR_MESSAGE)]
        public string Name { get; set; }

        [Required(ErrorMessage = ERROR_MESSAGE)]
        public string Email { get; set; }

        [Required(ErrorMessage = ERROR_MESSAGE)]
        public string Subject { get; set; }

        [MaxLength(1000, ErrorMessage = "Must be lesser than 1000 characters")]
        [Required(ErrorMessage = ERROR_MESSAGE)]
        public string Message { get; set; }
    }
}
