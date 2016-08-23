using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class Video
    {
        [Key]
        public string VideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
    }
}