using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;
using PagedList;
using PagedList.Mvc;
using MvcBlog.ViewModel;
using Microsoft.AspNet.Identity;

namespace MvcBlog.Controllers
{
    public class VideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Videos
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var carVideo = db.Videos.Include(g => g.Id);
            var carVideoLinks = db.Videos.Include(g => g.Id);
            List<Video> allVideos = db.Videos.ToList();
            PagedList<Video> singlePage = new PagedList<Video>(allVideos, page, pageSize);
            this.ViewBag.CarVideoLinks = carVideoLinks;
            return View(singlePage);
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            this.Session["videoPostId"] = video.Id;
            var myViewModel = new VideoViewModel();
            var lastItem = db.Videos.OrderByDescending(x => x.Id).First();
            var firstItem = db.Videos.OrderBy(x => x.Id).First();
            var videoComments = db.VideoComments.Where(c => c.Post.Id == video.Id).Include(c => c.Author).ToList();
            List<Video> prev = db.Videos.Where(x => x.Id < video.Id).ToList();
            var prevVid = video;
            if (prev.Count >0 )
            { 
             prevVid = prev[prev.Count - 1];
            }
            var nextVid = db.Videos.Where(x => x.Id > video.Id).FirstOrDefault();
            var prevId = firstItem.Id;
            var nextId = lastItem.Id;
            if (video.Id != firstItem.Id)
            {
                prevId = prevVid.Id;
            }
            prevId = prevVid.Id;
            if (video.Id != lastItem.Id)
            {
                nextId = nextVid.Id;
            }
            myViewModel.previousVideoId = prevId;
            myViewModel.nextVideoId = nextId;
            myViewModel.lastVIdeoItemID = lastItem.Id;
            myViewModel.firstVideoID = firstItem.Id;
            myViewModel.video = video;
            myViewModel.videoComments = videoComments;
            ViewBag.PostId = video.Id;
            return View(myViewModel);

            
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Administrators")]
        public ActionResult Create([Bind(Include = "Id,Title,Url,Description")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrators")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Url,Description")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteConfirmed(int? id)
        {

            Video video = db.Videos.Find(id);
            var comments = db.VideoComments.Where(c => c.Post.Id == id).ToList();
            foreach (var item in comments)
            {
                db.VideoComments.Remove(item);
            }
            db.Videos.Remove(video);
            db.SaveChanges();
           
            return RedirectToAction("Index");
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
