using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.ViewModel
{
    public class GalleryCarViewModel
    {
       public List<Comment> carComments { get; set; }
       public int firstItemID { get; set; }
       public int lastItemID { get; set; }
       public GalleryCar Car { get; set; }
       public int previousId { get; set; }
       public int nextId { get; set; }
       
    }
}