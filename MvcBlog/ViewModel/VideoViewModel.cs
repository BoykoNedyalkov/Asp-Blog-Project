using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.ViewModel
{
    public class VideoViewModel
    {
        public List<Comment> videoComments { get; set; }
        public int firstItemID { get; set; }
        public int lastItemID { get; set; }
        public Video CarVideo { get; set; }
    }
}