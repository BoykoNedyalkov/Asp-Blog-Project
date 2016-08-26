using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcBlog.Models
{
    public class ContactForm
    {
        [Required, Display(Name = "Your name")]
        public string Name { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        
    }
}