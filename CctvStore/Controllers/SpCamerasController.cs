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
    public class SpCamerasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpCameras
        public ActionResult Index()
        {
            var spCameras = db.SpCameras.Include(s => s.Specification);
            return View(spCameras.ToList());
        }

        // GET: SpCameras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpCamera spCamera = db.SpCameras.Find(id);
            if (spCamera == null)
            {
                return HttpNotFound();
            }
            return View(spCamera);
        }

        // GET: SpCameras/Create
        public ActionResult Create()
        {
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name");
            return View();
        }

        // POST: SpCameras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecificationId,ImageSensor,MinIllumination,DayNight,ShutterSpeed,AutoIris,WideDynamicRange,DigitalNoiseReduction,Lens,FOV,IRLED,IRRange,SN,SignalSystem,DetecterType,ArrayFormal,PixelPitch,Sensitivity,SpecteralRange,TemperatureDetection,Focus,DetectDistanceVehicle,DetectDistanceHumen,RecognizeDistance")] SpCamera spCamera)
        {
            if (ModelState.IsValid)
            {
                db.SpCameras.Add(spCamera);
                db.SaveChanges();
                return RedirectToAction("HomeSpecification","Home");
            }

            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spCamera.SpecificationId);
            return View(spCamera);
        }

        // GET: SpCameras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpCamera spCamera = db.SpCameras.Find(id);
            if (spCamera == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spCamera.SpecificationId);
            return View(spCamera);
        }

        // POST: SpCameras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecificationId,ImageSensor,MinIllumination,DayNight,ShutterSpeed,AutoIris,WideDynamicRange,DigitalNoiseReduction,Lens,FOV,IRLED,IRRange,SN,SignalSystem,DetecterType,ArrayFormal,PixelPitch,Sensitivity,SpecteralRange,TemperatureDetection,Focus,DetectDistanceVehicle,DetectDistanceHumen,RecognizeDistance")] SpCamera spCamera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spCamera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spCamera.SpecificationId);
            return View(spCamera);
        }

        // GET: SpCameras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpCamera spCamera = db.SpCameras.Find(id);
            if (spCamera == null)
            {
                return HttpNotFound();
            }
            return View(spCamera);
        }

        // POST: SpCameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpCamera spCamera = db.SpCameras.Find(id);
            db.SpCameras.Remove(spCamera);
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
