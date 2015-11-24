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
    public class SpNetworksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpNetworks
        public ActionResult Index()
        {
            var spNetworks = db.SpNetworks.Include(s => s.Specification);
            return View(spNetworks.ToList());
        }

        // GET: SpNetworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpNetwork spNetwork = db.SpNetworks.Find(id);
            if (spNetwork == null)
            {
                return HttpNotFound();
            }
            return View(spNetwork);
        }

        // GET: SpNetworks/Create
        public ActionResult Create()
        {
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name");
            return View();
        }

        // POST: SpNetworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecificationId,NetworkProtocols,AlarmTrigger,RTSPVideo,Security,WebLanguage,SystemCompatibility,NetworkInterface,POEInterface,POEMaxPower")] SpNetwork spNetwork)
        {
            if (ModelState.IsValid)
            {
                db.SpNetworks.Add(spNetwork);
                db.SaveChanges();
                return RedirectToAction("HomeSpecification", "Home");
            }

            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spNetwork.SpecificationId);
            return View(spNetwork);
        }

        // GET: SpNetworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpNetwork spNetwork = db.SpNetworks.Find(id);
            if (spNetwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spNetwork.SpecificationId);
            return View(spNetwork);
        }

        // POST: SpNetworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecificationId,NetworkProtocols,AlarmTrigger,RTSPVideo,Security,WebLanguage,SystemCompatibility,NetworkInterface,POEInterface,POEMaxPower")] SpNetwork spNetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spNetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spNetwork.SpecificationId);
            return View(spNetwork);
        }

        // GET: SpNetworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpNetwork spNetwork = db.SpNetworks.Find(id);
            if (spNetwork == null)
            {
                return HttpNotFound();
            }
            return View(spNetwork);
        }

        // POST: SpNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpNetwork spNetwork = db.SpNetworks.Find(id);
            db.SpNetworks.Remove(spNetwork);
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
