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
    public class SpecificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult HomeSpecification()
        {
            return View();
        }
        // GET: Specifications
        public ActionResult Index(int? ProductId)
        {
            var specifications = db.Specifications.Where(x => x.ProductId.ToString().Contains(ProductId.ToString())).Include(s => s.Product).Include(s => s.SpAudio).Include(s => s.SpCamera).Include(s => s.SpGeneral).Include(s => s.SpHardDisk).Include(s => s.SpImage).Include(s => s.SpInterface).Include(s => s.SpNetwork).Include(s => s.SpRecordPlayback).Include(s => s.SpVideo).Include(s => s.SpVideoAudioInput).Include(s => s.SpVideoAudioOutput);
            return View(specifications);
        }

        // GET: Specifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            return View(specification);
        }

        // GET: Specifications/Create
        public ActionResult Create(int? ProductId)
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.SpecificationId = new SelectList(db.SpAudios, "SpecificationId", "AudioCompression");
            ViewBag.SpecificationId = new SelectList(db.SpCameras, "SpecificationId", "ImageSensor");
            ViewBag.SpecificationId = new SelectList(db.SpGenerals, "SpecificationId", "PowerSupply");
            ViewBag.SpecificationId = new SelectList(db.SpHardDisks, "SpecificationId", "SATAHDD");
            ViewBag.SpecificationId = new SelectList(db.SpImages, "SpecificationId", "EffectiveResolution");
            ViewBag.SpecificationId = new SelectList(db.SpInterfaces, "SpecificationId", "Ethernet");
            ViewBag.SpecificationId = new SelectList(db.SpNetworks, "SpecificationId", "NetworkProtocols");
            ViewBag.SpecificationId = new SelectList(db.SpRecordPlaybacks, "SpecificationId", "HardDrive");
            ViewBag.SpecificationId = new SelectList(db.SpVideos, "SpecificationId", "VideoCompression");
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioInputs, "SpecificationId", "VideoInput");
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioOutputs, "SpecificationId", "RecordingResolution");
            return View();
        }

        // POST: Specifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecificationId,Name,ProductId")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Specifications.Add(specification);
                db.SaveChanges();
               // return RedirectToAction("Index");
                return RedirectToAction("Index", "Specifications", new { @ProductId = specification.ProductId });
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", specification.ProductId);
            ViewBag.SpecificationId = new SelectList(db.SpAudios, "SpecificationId", "AudioCompression", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpCameras, "SpecificationId", "ImageSensor", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpGenerals, "SpecificationId", "PowerSupply", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpHardDisks, "SpecificationId", "SATAHDD", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpImages, "SpecificationId", "EffectiveResolution", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpInterfaces, "SpecificationId", "Ethernet", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpNetworks, "SpecificationId", "NetworkProtocols", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpRecordPlaybacks, "SpecificationId", "HardDrive", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideos, "SpecificationId", "VideoCompression", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioInputs, "SpecificationId", "VideoInput", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioOutputs, "SpecificationId", "RecordingResolution", specification.SpecificationId);
            return View(specification);
        }

        // GET: Specifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", specification.ProductId);
            ViewBag.SpecificationId = new SelectList(db.SpAudios, "SpecificationId", "AudioCompression", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpCameras, "SpecificationId", "ImageSensor", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpGenerals, "SpecificationId", "PowerSupply", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpHardDisks, "SpecificationId", "SATAHDD", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpImages, "SpecificationId", "EffectiveResolution", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpInterfaces, "SpecificationId", "Ethernet", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpNetworks, "SpecificationId", "NetworkProtocols", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpRecordPlaybacks, "SpecificationId", "HardDrive", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideos, "SpecificationId", "VideoCompression", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioInputs, "SpecificationId", "VideoInput", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioOutputs, "SpecificationId", "RecordingResolution", specification.SpecificationId);
            return View(specification);
        }

        // POST: Specifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecificationId,Name,ProductId")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", specification.ProductId);
            ViewBag.SpecificationId = new SelectList(db.SpAudios, "SpecificationId", "AudioCompression", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpCameras, "SpecificationId", "ImageSensor", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpGenerals, "SpecificationId", "PowerSupply", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpHardDisks, "SpecificationId", "SATAHDD", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpImages, "SpecificationId", "EffectiveResolution", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpInterfaces, "SpecificationId", "Ethernet", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpNetworks, "SpecificationId", "NetworkProtocols", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpRecordPlaybacks, "SpecificationId", "HardDrive", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideos, "SpecificationId", "VideoCompression", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioInputs, "SpecificationId", "VideoInput", specification.SpecificationId);
            ViewBag.SpecificationId = new SelectList(db.SpVideoAudioOutputs, "SpecificationId", "RecordingResolution", specification.SpecificationId);
            return View(specification);
        }

        // GET: Specifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            return View(specification);
        }

        // POST: Specifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specification specification = db.Specifications.Find(id);
            db.Specifications.Remove(specification);
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
