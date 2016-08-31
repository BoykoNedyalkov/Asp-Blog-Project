using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;
using Microsoft.AspNet.Identity;

namespace MvcBlog.Controllers
{
    public class VideoCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VideoComments
        public ActionResult Index()
        {
            return View(db.VideoComments.ToList());
        }

        // GET: VideoComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComments.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            return View(videoComment);
        }

        // GET: VideoComments/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Text,Date,postId,authorId")] VideoComment videoComment)
        {
            var postId = (int)this.Session["videoPostId"];
            var postObj = db.Videos.Where(p => p.Id == postId).Single();
            videoComment.Post = postObj;
            var authorId = User.Identity.GetUserId();
            var authorObj = db.Users.Where(u => u.Id == authorId).Single();
            videoComment.Author = authorObj;
            var date = DateTime.Now;
            videoComment.Date = date;
            if (ModelState.IsValid)
            {
                db.VideoComments.Add(videoComment);
                db.SaveChanges();
                return RedirectToAction("Details", "Videos", new { postObj.Id });
            }

            return View(videoComment);
        }

        // GET: VideoComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComments.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            return View(videoComment);
        }

        // POST: VideoComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date")] VideoComment videoComment)
        {
            var postId = (int)this.Session["videoPostId"];
            var postObj = db.Videos.Where(p => p.Id == postId).Single();
            videoComment.Post = postObj;
            var authorId = User.Identity.GetUserId();
            var authorObj = db.Users.Where(u => u.Id == authorId).Single();
            videoComment.Author = authorObj;
            var date = DateTime.Now;
            videoComment.Date = date;
            if (ModelState.IsValid)
            {
                db.Entry(videoComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Videos", new { postObj.Id });
            }
            return View(videoComment);
        }

        // GET: VideoComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComments.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            return View(videoComment);
        }

        // POST: VideoComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var postId = (int)this.Session["videoPostId"];
            var postObj = db.Videos.Where(p => p.Id == postId).Single();
            
            VideoComment videoComment = db.VideoComments.Find(id);
            db.VideoComments.Remove(videoComment);
            db.SaveChanges();
            return RedirectToAction("Details", "Videos", new { postObj.Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
