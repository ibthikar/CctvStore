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
    public class CatalogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //[HttpPost]
      //  [ValidateAntiForgeryToken]
        [ChildActionOnly]
        public ActionResult Create1([Bind(Include = "CatalogId,CatalogName")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Catalogs.Add(catalog);
                db.SaveChanges();
                return RedirectToAction("Admin", "Home");
            }

            return PartialView(catalog);
        }


        // GET: Catalogs
        public ActionResult Index()
        {
            return View(db.Catalogs.ToList());
        }

        // GET: Catalogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        // GET: Catalogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "CatalogId,CatalogName")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Catalogs.Add(catalog);
                db.SaveChanges();
                return RedirectToAction("Admin","Home");
            }

            return View(catalog);
        }

        // GET: Catalogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        // POST: Catalogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatalogId,CatalogName")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalog);
        }

        // GET: Catalogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalog catalog = db.Catalogs.Find(id);
            db.Catalogs.Remove(catalog);
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
