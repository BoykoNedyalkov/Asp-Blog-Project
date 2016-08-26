using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcBlog.Models;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

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

        [HttpPost]      
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contacts(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("recipient@gmail.com")); 
                message.From = new MailAddress("sender@outlook.com");
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.Name, model.Email, model.Body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "teambik2016@gmail.com",
                        Password = "project123"  
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult References()
        {
            return View();
        }
    }
}