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
    public class SpGeneralsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpGenerals
        public ActionResult Index()
        {
            var spGenerals = db.SpGenerals.Include(s => s.Specification);
            return View(spGenerals.ToList());
        }

        // GET: SpGenerals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpGeneral spGeneral = db.SpGenerals.Find(id);
            if (spGeneral == null)
            {
                return HttpNotFound();
            }
            return View(spGeneral);
        }

        // GET: SpGenerals/Create
        public ActionResult Create()
        {
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name");
            return View();
        }

        // POST: SpGenerals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecificationId,PowerSupply,PowerConsumption,OperatureTemperature,IngressProtection,Approvals,ProductDimensions,ProductWeight,Materials,Size,Chasis")] SpGeneral spGeneral)
        {
            if (ModelState.IsValid)
            {
                db.SpGenerals.Add(spGeneral);
                db.SaveChanges();
                return RedirectToAction("HomeSpecification", "Home");
            }

            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spGeneral.SpecificationId);
            return View(spGeneral);
        }

        // GET: SpGenerals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpGeneral spGeneral = db.SpGenerals.Find(id);
            if (spGeneral == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spGeneral.SpecificationId);
            return View(spGeneral);
        }

        // POST: SpGenerals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecificationId,PowerSupply,PowerConsumption,OperatureTemperature,IngressProtection,Approvals,ProductDimensions,ProductWeight,Materials,Size,Chasis")] SpGeneral spGeneral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spGeneral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecificationId = new SelectList(db.Specifications, "SpecificationId", "Name", spGeneral.SpecificationId);
            return View(spGeneral);
        }

        // GET: SpGenerals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpGeneral spGeneral = db.SpGenerals.Find(id);
            if (spGeneral == null)
            {
                return HttpNotFound();
            }
            return View(spGeneral);
        }

        // POST: SpGenerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpGeneral spGeneral = db.SpGenerals.Find(id);
            db.SpGenerals.Remove(spGeneral);
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
