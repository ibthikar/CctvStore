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
    public class SpInterfacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpInterfaces
        public ActionResult Index()
        {
            var spInterfaces = db.SpInterfaces.Include(s => s.Specification);
            return View(spInterfaces.ToList());
        }

        // GET: SpInterfaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpInterface spInterface = db.SpInterfaces.Find(id);
            if (spInterface == null)
            {
                return HttpNotFound();
            }
            return View(spInterface);
        }

        // GET: SpInterfaces/Create
        public ActionResult Create()
        {
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name");
            return View();
        }

        // POST: SpInterfaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecificationId,Ethernet,AudioIO,AlarmIO,RS485,BNCOutput,ResetButton,EdgeStorage,Output,PTZControl,Network,USB,HDMIVGA")] SpInterface spInterface)
        {
            if (ModelState.IsValid)
            {
                db.SpInterfaces.Add(spInterface);
                db.SaveChanges();
                return RedirectToAction("HomeSpecification", "Home");
            }

            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spInterface.SpecificationId);
            return View(spInterface);
        }

        // GET: SpInterfaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpInterface spInterface = db.SpInterfaces.Find(id);
            if (spInterface == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spInterface.SpecificationId);
            return View(spInterface);
        }

        // POST: SpInterfaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecificationId,Ethernet,AudioIO,AlarmIO,RS485,BNCOutput,ResetButton,EdgeStorage,Output,PTZControl,Network,USB,HDMIVGA")] SpInterface spInterface)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spInterface).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spInterface.SpecificationId);
            return View(spInterface);
        }

        // GET: SpInterfaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpInterface spInterface = db.SpInterfaces.Find(id);
            if (spInterface == null)
            {
                return HttpNotFound();
            }
            return View(spInterface);
        }

        // POST: SpInterfaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpInterface spInterface = db.SpInterfaces.Find(id);
            db.SpInterfaces.Remove(spInterface);
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
