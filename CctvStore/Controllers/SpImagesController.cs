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
    public class SpImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpImages
        public ActionResult Index()
        {
            var spImages = db.SpImages.Include(s => s.Specification);
            return View(spImages.ToList());
        }

        // GET: SpImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpImage spImage = db.SpImages.Find(id);
            if (spImage == null)
            {
                return HttpNotFound();
            }
            return View(spImage);
        }

        // GET: SpImages/Create
        public ActionResult Create()
        {
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name");
            return View();
        }

        // POST: SpImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecificationId,EffectiveResolution,WhiteBalance,Gain,LightCompensation,DigitalZoom,MotionDetection,PrivateMask,OSDLanguage,Defog,DigitalImageStable,UTC,VideoCompression,BitRate,AudioCompression,MaxResolution,Stream,ImageSetting,DeWrapping,HLC,CorridorMode,ROI,EffectivePixel,DVEImageEnhance,ImageColorMode,NoiseReduce,ImageCorrection,ImageOverturn")] SpImage spImage)
        {
            if (ModelState.IsValid)
            {
                db.SpImages.Add(spImage);
                db.SaveChanges();
                return RedirectToAction("HomeSpecification", "Home");
            }

            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spImage.SpecificationId);
            return View(spImage);
        }

        // GET: SpImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpImage spImage = db.SpImages.Find(id);
            if (spImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spImage.SpecificationId);
            return View(spImage);
        }

        // POST: SpImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecificationId,EffectiveResolution,WhiteBalance,Gain,LightCompensation,DigitalZoom,MotionDetection,PrivateMask,OSDLanguage,Defog,DigitalImageStable,UTC,VideoCompression,BitRate,AudioCompression,MaxResolution,Stream,ImageSetting,DeWrapping,HLC,CorridorMode,ROI,EffectivePixel,DVEImageEnhance,ImageColorMode,NoiseReduce,ImageCorrection,ImageOverturn")] SpImage spImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spImage.SpecificationId);
            return View(spImage);
        }

        // GET: SpImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpImage spImage = db.SpImages.Find(id);
            if (spImage == null)
            {
                return HttpNotFound();
            }
            return View(spImage);
        }

        // POST: SpImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpImage spImage = db.SpImages.Find(id);
            db.SpImages.Remove(spImage);
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
