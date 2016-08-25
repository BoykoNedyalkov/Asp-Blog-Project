using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;
using MvcBlog.ViewModel;
using PagedList;
using PagedList.Mvc;

namespace MvcBlog.Controllers
{
    [ValidateInput(false)]
    public class GalleryCarsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: GalleryCars
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            var cars = db.GalleryCars.Include(g => g.Id);
            var carLinks = db.GalleryCars.Include(g => g.Id);
            List<GalleryCar> galleryCars = db.GalleryCars.ToList();
            PagedList<GalleryCar> singlePage = new PagedList<GalleryCar>(galleryCars, page, pageSize);
            this.ViewBag.CarLinks = carLinks;
            return View(singlePage);
        }

        // GET: GalleryCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryCar galleryCar = db.GalleryCars.Find(id);
            if (galleryCar == null)
            {
                return HttpNotFound();
            }
            this.Session["postId"] = galleryCar.Id;
            var myViewModel = new GalleryCarViewModel();
            var lastItem = db.GalleryCars.OrderByDescending(x => x.Id).First();
            var firstItem = db.GalleryCars.OrderBy(x => x.Id).First();
            var carComments = db.Comments.Where(c => c.Post.Id == galleryCar.Id).Include(c => c.Author).ToList();
            myViewModel.lastItemID = lastItem.Id;
            myViewModel.firstItemID = firstItem.Id;
            myViewModel.Car = galleryCar;
            myViewModel.carComments = carComments;
            ViewBag.PostId = galleryCar.Id;
            return View(myViewModel);
        }

        // GET: GalleryCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GalleryCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,URL,Description")] GalleryCar galleryCar)
        {
            if (ModelState.IsValid)
            {
                db.GalleryCars.Add(galleryCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galleryCar);
        }

        // GET: GalleryCars/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryCar galleryCar = db.GalleryCars.Find(id);
            if (galleryCar == null)
            {
                return HttpNotFound();
            }
            return View(galleryCar);
        }

        // POST: GalleryCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,URL,Description")] GalleryCar galleryCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galleryCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galleryCar);
        }

        // GET: GalleryCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryCar galleryCar = db.GalleryCars.Find(id);
            if (galleryCar == null)
            {
                return HttpNotFound();
            }
            return View(galleryCar);
        }
        

        // POST: GalleryCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GalleryCar galleryCar = db.GalleryCars.Find(id);
            db.GalleryCars.Remove(galleryCar);
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
