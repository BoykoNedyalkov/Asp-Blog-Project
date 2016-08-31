using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.ViewModel
{
    public class VideoViewModel
    {
        public List<VideoComment> videoComments { get; set; }
        public int firstVideoID { get; set; }
        public int lastVIdeoItemID { get; set; }
        public Video video { get; set; }
        public int nextVideoId { get; set; }
        public int previousVideoId { get; set; }
    }
}