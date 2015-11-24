using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CctvStore.Models;

namespace CctvStore.Controllers
{
    public class SpVideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpVideos
        public ActionResult Index()
        {
            var spVideos = db.SpVideos.Include(s => s.Specification);
            return View(spVideos.ToList());
        }

        // GET: SpVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpVideo spVideo = db.SpVideos.Find(id);
            if (spVideo == null)
            {
                return HttpNotFound();
            }
            return View(spVideo);
        }

        // GET: SpVideos/Create
        public ActionResult Create()
        {
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name");
            return View();
        }

        // POST: SpVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecificationId,VideoCompression,EncodeAbility,DecodeAbility,VideoInput")] SpVideo spVideo)
        {
            if (ModelState.IsValid)
            {
                db.SpVideos.Add(spVideo);
                db.SaveChanges();
                return RedirectToAction("HomeSpecification", "Home");
            }

            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spVideo.SpecificationId);
            return View(spVideo);
        }

        // GET: SpVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpVideo spVideo = db.SpVideos.Find(id);
            if (spVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spVideo.SpecificationId);
            return View(spVideo);
        }

        // POST: SpVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecificationId,VideoCompression,EncodeAbility,DecodeAbility,VideoInput")] SpVideo spVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spVideo.SpecificationId);
            return View(spVideo);
        }

        // GET: SpVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpVideo spVideo = db.SpVideos.Find(id);
            if (spVideo == null)
            {
                return HttpNotFound();
            }
            return View(spVideo);
        }

        // POST: SpVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpVideo spVideo = db.SpVideos.Find(id);
            db.SpVideos.Remove(spVideo);
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
