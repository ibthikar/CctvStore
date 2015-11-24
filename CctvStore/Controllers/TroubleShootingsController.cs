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
    public class TroubleShootingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TroubleShootings
        public ActionResult Index()
        {
            return View(db.TroubleShootings.ToList());
        }

        // GET: TroubleShootings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroubleShooting troubleShooting = db.TroubleShootings.Find(id);
            if (troubleShooting == null)
            {
                return HttpNotFound();
            }
            return View(troubleShooting);
        }

        // GET: TroubleShootings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TroubleShootings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TroubleShootingId,ErrorTitle,ErrorDescription,ErrorUrl,DateCreated")] TroubleShooting troubleShooting)
        {
            if (ModelState.IsValid)
            {
                db.TroubleShootings.Add(troubleShooting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(troubleShooting);
        }

        // GET: TroubleShootings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroubleShooting troubleShooting = db.TroubleShootings.Find(id);
            if (troubleShooting == null)
            {
                return HttpNotFound();
            }
            return View(troubleShooting);
        }

        // POST: TroubleShootings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TroubleShootingId,ErrorTitle,ErrorDescription,ErrorUrl,DateCreated")] TroubleShooting troubleShooting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(troubleShooting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(troubleShooting);
        }

        // GET: TroubleShootings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroubleShooting troubleShooting = db.TroubleShootings.Find(id);
            if (troubleShooting == null)
            {
                return HttpNotFound();
            }
            return View(troubleShooting);
        }

        // POST: TroubleShootings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TroubleShooting troubleShooting = db.TroubleShootings.Find(id);
            db.TroubleShootings.Remove(troubleShooting);
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
