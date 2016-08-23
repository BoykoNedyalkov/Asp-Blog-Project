using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(3);
            var sidebarPosts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(5);
            this.ViewBag.SideBarPosts = sidebarPosts;
            return View(posts.ToList());
        }
        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult References()
        {
            return View();
        }
    }
}