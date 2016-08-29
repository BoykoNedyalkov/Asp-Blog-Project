﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class Comment
    {
        public Comment()
        {
            Date = DateTime.Now;
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(140)]
        public string Text { get; set; }
        public GalleryCar Post { get; set; }
        public Video VideoPost { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime Date { get; set; }
        
    }
}