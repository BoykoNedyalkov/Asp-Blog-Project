using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class GalleryCar
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public string Description { get; set; }
    }
}